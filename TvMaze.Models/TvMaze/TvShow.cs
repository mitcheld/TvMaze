using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TvMaze.Models.TvMaze
{
    public class TvShow
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [JsonProperty(PropertyName = "_Embedded")]
        public Embedded Embedded { get; set; }

        public static implicit operator Show(TvShow show)
        {
            return new Show()
            {
                OriginalId = show.Id,
                Name = show.Name,
                CastMembers = show.Embedded.Cast.Select(x => (CastMember)x.Person).ToList()
            };
        }
    }

    public class Embedded
    {
        public Cast[] Cast { get; set; }
    }

    public class Cast
    {
        public Person Person { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDay { get; set; }

        public static implicit operator CastMember(Person person)
        {
            return new CastMember()
            {
                OriginalId = person.Id,
                Name = person.Name,
                BirthDay = person.BirthDay
            };
        }
    }
}
