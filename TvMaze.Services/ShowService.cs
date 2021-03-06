﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvMaze.Infrastructure;
using TvMaze.Infrastructure.Models;
using TvMaze.Services.Interfaces;

namespace TvMaze.Services
{
    public class ShowService : Service<Show>, IShowService
    {
        private readonly ILogger<ShowService> _logger;

        public ShowService(DatabaseContext context, ILogger<ShowService> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<List<Show>> GetWithCastMembers(int startIndex, int pageSize)
        {
            var shows = await Context.Shows.Skip(startIndex).Take(pageSize).Include(x => x.CastMembers).ToListAsync();
            foreach (var show in shows)
            {
                show.CastMembers = show.CastMembers.OrderByDescending(x => x.BirthDay).ToList();
            }
            return shows;
        }

        public async Task Add(IEnumerable<Show> shows)
        {
            try
            {
                await Context.Shows.AddRangeAsync(shows);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured getting tv shows. {ex}");
            }
        }
    }
}
