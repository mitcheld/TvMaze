using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TvMaze.Models;
using TvMaze.Services.Interfaces;

namespace TvMaze.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowController(IShowService showService)
        {
            _showService = showService;
        }

        // https://localhost:44305/api/show?startIndex=1&pageSize=5
        [HttpGet]
        public async Task<ActionResult<List<Show>>> Get(int startIndex = 0, int pageSize = 5)
        {
            // Get data from DB
            var shows = await _showService.GetShowsWithCastMembers(startIndex, pageSize);

            return shows;
        }
    }
}