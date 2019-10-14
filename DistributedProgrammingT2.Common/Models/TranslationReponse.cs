using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedProgrammingT2.Common.Models
{
    public class TranslationReponse
    {
        [JsonProperty(PropertyName = "de")]
        public string De { get; set; }

        [JsonProperty(PropertyName = "es")]
        public string Es { get; set; }

        [JsonProperty(PropertyName = "fr")]
        public string Fr { get; set; }

        [JsonProperty(PropertyName = "ja")]
        public string Ja { get; set; }

        [JsonProperty(PropertyName = "it")]
        public string It { get; set; }

        [JsonProperty(PropertyName = "br")]
        public string Br { get; set; }

        [JsonProperty(PropertyName = "pt")]
        public string Pt { get; set; }

        [JsonProperty(PropertyName = "nl")]
        public string Nl { get; set; }

        [JsonProperty(PropertyName = "hr")]
        public string Hr { get; set; }

        [JsonProperty(PropertyName = "fa")]
        public string Fa { get; set; }
    }
}
