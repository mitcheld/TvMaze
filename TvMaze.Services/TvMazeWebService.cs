using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TvMaze.Infrastructure.Models;
using TvMaze.Infrastructure.Models.TvMaze;
using TvMaze.Services.Interfaces;

namespace TvMaze.Services
{
    public class TvMazeWebService : ITvMazeWebService
    {
        private readonly HttpClient _client;
        private readonly ILogger<TvMazeWebService> _logger;
        private readonly IShowService _showService;

        private readonly List<TvShow> _shows;

        public TvMazeWebService(HttpClient client, ILogger<TvMazeWebService> logger, IShowService showService)
        {
            _client = client;
            _logger = logger;
            _showService = showService;

            _shows = new List<TvShow>();
        }

        public async Task CollectShowsWithCast()
        {
            if (await _showService.Count() > 0) return;

            try
            {
                var ids = new List<int>();

                // Todo: This should be replaced by a better way of fetching all shows
                for (var i = 1; i < 999999; i++) ids.Add(i);

                await Task.WhenAll(ids.Select(GetShowWithCast));

                await _showService.Add(new List<Show>(_shows.Select(x => (Show)x)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured getting tv shows {ex}");
            }
        }

        private async Task GetShowWithCast(int id)
        {
            try
            {
                var response = await _client.GetAsync($"shows/{id}?embed=cast");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var show = JsonConvert.DeserializeObject<TvShow>(json);
                    _shows.Add(show);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured getting tv show {id}, {ex}");
            }
        }
    }
}
