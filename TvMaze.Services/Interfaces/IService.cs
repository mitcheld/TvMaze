using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Infrastructure.Models;

namespace TvMaze.Services.Interfaces
{
    public interface IService<T> where T : Entity
    {
        Task<int> Count();
        Task<T> Get(int id);
        Task<List<T>> Get();
    }
}
