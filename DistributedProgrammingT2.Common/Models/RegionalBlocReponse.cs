using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedProgrammingT2.Common.Models
{
    public class RegionalBlocReponse
    {
        [JsonProperty(PropertyName = "acronym")]
        public string Acronym { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        /*[JsonProperty(PropertyName = "de")]
        public ICollection<object> otherAcronyms { get; set; }

        public ICollection<object> otherNames { get; set; } */
    }
}
