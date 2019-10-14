using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DistributedProgrammingT2.Common.Models
{
    public class CurrencyResponse
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
    }
}
