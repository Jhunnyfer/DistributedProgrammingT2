using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedProgrammingT2.Common.Models
{
    public class CountryResponse
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "topLevelDomain")]
        public List<string> TopLevelDomain { get; set; }

        [JsonProperty(PropertyName = "alpha2Code")]
        public string Alpha2Code { get; set; }

        [JsonProperty(PropertyName = "alpha3Code")]
        public string Alpha3Code { get; set; }

        [JsonProperty(PropertyName = "callingCodes")]
        public List<string> CallingCodes { get; set; }

        [JsonProperty(PropertyName = "capital")]
        public string Capital { get; set; }

        [JsonProperty(PropertyName = "acronym")]
        public string Acronym { get; set; }

        [JsonProperty(PropertyName = "altSpellings")]
        public List<string> AltSpellings { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "subregion")]
        public string Subregion { get; set; }

        [JsonProperty(PropertyName = "population")]
        public int Population { get; set; }

        [JsonProperty(PropertyName = "latlng")]
        public List<double> Latlng { get; set; }

        [JsonProperty(PropertyName = "demonym")]
        public string Demonym { get; set; }

        [JsonProperty(PropertyName = "area")]
        public double? Area { get; set; }

        [JsonProperty(PropertyName = "gini")]
        public double? Gini { get; set; }

        [JsonProperty(PropertyName = "timezones")]
        public List<string> Timezones { get; set; }

        [JsonProperty(PropertyName = "borders")]
        public List<string>? Borders { get; set; }

        [JsonProperty(PropertyName = "nativeName")]
        public string NativeName { get; set; }

        [JsonProperty(PropertyName = "numericCode")]
        public string NumericCode { get; set; }

        [JsonProperty(PropertyName = "currencyResponse")]
        public List<CurrencyResponse> CurrencyResponse { get; set; }

        [JsonProperty(PropertyName = "flag")]
        public string Flag { get; set; }

        /*[JsonProperty(PropertyName = "language")]
        public List<LanguageResponse> Language { get; set; }

        [JsonProperty(PropertyName = "translation")]
        public TranslationReponse Translation { get; set; }

        [JsonProperty(PropertyName = "regionalBlocs")]
        public List<RegionalBlocReponse> RegionalBlocs { get; set; }

        [JsonProperty(PropertyName = "cioc")]
        public string Cioc { get; set; }*/
    }
}
