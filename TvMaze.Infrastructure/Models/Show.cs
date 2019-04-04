using System.Collections.Generic;
using Newtonsoft.Json;

namespace TvMaze.Infrastructure.Models
{
    public class Show : Entity
    {
        [JsonProperty(PropertyName = "id")]
        public int OriginalId { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "cast")]
        public List<CastMember> CastMembers { get; set; }
    }
}
