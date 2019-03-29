using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvMaze.Infrastructure;
using TvMaze.Models;
using TvMaze.Services.Interfaces;

namespace TvMaze.Services
{
    public class Service<T> : IService<T> where T : Entity
    {
        protected readonly DatabaseContext Context;

        protected Service(DatabaseContext context)
        {
            Context = context;
        }

        public async Task<int> Count()
        {
            return await Context.Set<T>().CountAsync();
        }
    }
}
