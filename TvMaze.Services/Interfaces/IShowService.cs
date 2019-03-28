using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvMaze.Infrastructure;
using TvMaze.Models;

namespace TvMaze.Services.Interfaces
{
    public interface IShowService : IService<Show>
    {
        Task<List<Show>> GetShowsWithCastMembers(int startIndex, int pageSize);
        Task AddShowsWithCastMembers(List<Show> shows);
    }
}
