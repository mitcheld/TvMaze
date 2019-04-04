using System;
using Newtonsoft.Json;

namespace TvMaze.Infrastructure.Models
{
    public class CastMember : Entity
    {
        [JsonProperty(PropertyName = "id")]
        public int OriginalId { get; set; }

        public string Name { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}
