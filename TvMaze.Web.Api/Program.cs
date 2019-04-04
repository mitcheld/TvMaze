using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TvMaze.Services.Interfaces;

namespace TvMaze.Web.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            // Create a new scope
            using (var scope = webHost.Services.CreateScope())
            {
                // Get the DbContext instance
                var tvMazeService = scope.ServiceProvider.GetRequiredService<ITvMazeWebService>();
                await tvMazeService.CollectShowsWithCast();
            }

            // Run the WebHost, and start accepting requests
            // There's an async overload, so we may as well use it
            await webHost.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
