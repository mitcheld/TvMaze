using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TvMaze.Infrastructure;
using TvMaze.Infrastructure.Models;
using TvMaze.Services.Interfaces;

namespace TvMaze.Services
{
    /// <summary>
    /// Contains operations you can use on any Entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

        public async Task<List<T>> Get()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync();
        }
    }
}
