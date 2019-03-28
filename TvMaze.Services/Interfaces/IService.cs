using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvMaze.Models;

namespace TvMaze.Services.Interfaces
{
    public interface IService<T> where T : Entity
    {
        Task<int> Count();
        DbSet<T> Data();
        Task<int> SaveChangesAsync();
    }
}
