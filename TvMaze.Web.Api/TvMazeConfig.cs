using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvMaze.Web.Api
{
    public class TvMazeConfig
    {
        public string BaseUrl { get; set; }
        public int HttpMessageHandlerLifeTime { get; set; }
        public int RetryCount { get; set; }
        public bool UseJitterer { get; set; }
    }
}
