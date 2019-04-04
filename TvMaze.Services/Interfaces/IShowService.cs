using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Infrastructure.Models;

namespace TvMaze.Services.Interfaces
{
    public interface IShowService : IService<Show>
    {
        Task<List<Show>> GetWithCastMembers(int startIndex, int pageSize);
        Task Add(IEnumerable<Show> shows);
    }
}
