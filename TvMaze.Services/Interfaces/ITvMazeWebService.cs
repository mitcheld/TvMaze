using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TvMaze.Services.Interfaces
{
    public interface ITvMazeWebService
    {
        Task CollectShowsWithCast();
    }
}
