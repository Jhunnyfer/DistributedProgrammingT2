using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedProgrammingT2.Common.Models
{
    public class LanguageResponse
    {
        public string iso639_1 { get; set; }
        public string iso639_2 { get; set; }
        public string name { get; set; }
        public string nativeName { get; set; }
    }
}
