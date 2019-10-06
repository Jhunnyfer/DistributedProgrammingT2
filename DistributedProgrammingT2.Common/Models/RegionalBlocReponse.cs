using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedProgrammingT2.Common.Models
{
    public class RegionalBlocReponse
    {
        public string acronym { get; set; }
        public string name { get; set; }
        public List<object> otherAcronyms { get; set; }
        public List<object> otherNames { get; set; }
    }
}
