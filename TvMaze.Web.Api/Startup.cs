using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;
using TvMaze.Infrastructure;
using TvMaze.Services;
using TvMaze.Services.Interfaces;

namespace TvMaze.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var config = new TvMazeConfig();
            Configuration.GetSection("TvMaze").Bind(config);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHttpClient<ITvMazeWebService, TvMazeWebService>(client => client.BaseAddress = new Uri(config.BaseUrl))
                .SetHandlerLifetime(TimeSpan.FromMinutes(config.HttpMessageHandlerLifeTime))
                .AddPolicyHandler(GetRetryPolicy(config));

            services.AddTransient<IShowService, ShowService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        /// <summary>
        /// Get a configured policy used for HttpClients
        /// </summary>
        /// <returns></returns>
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(TvMazeConfig config)
        {
            // Using a Jitterer can improve the overall performance of the end-to-end system by adding randomness to the exponential backoff.
            // This spreads out the spikes when issues arise
            var jitterer = new Random();
            var jitterValue = config.UseJitterer ? TimeSpan.FromMilliseconds(jitterer.Next(0, 100)) : new TimeSpan(0);
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(config.RetryCount, // exponential back-off plus some jitter
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) + jitterValue);
        }
    }
}
