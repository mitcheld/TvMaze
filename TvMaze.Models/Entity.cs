using System;
using Newtonsoft.Json;

namespace TvMaze.Models
{
    public class Entity
    {
        public Entity()
        {
            DateCreated = DateTime.UtcNow;
        }

        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public DateTime DateModified { get; set; }
    }
}
