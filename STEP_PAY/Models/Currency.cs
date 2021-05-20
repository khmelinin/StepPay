using Newtonsoft.Json;

namespace STEP_PAY.Models
{
    internal class Currency
    {
        [JsonProperty(PropertyName = "r030")]
        public readonly int CurrencyCode;
        [JsonProperty(PropertyName = "txt")]
        public readonly string FullName;
        [JsonProperty(PropertyName = "rate")]
        public readonly double Rate;
        [JsonProperty(PropertyName = "cc")]
        public readonly string ShortName;
        [JsonProperty(PropertyName = "exchangedate")]
        public readonly string Exchangedate;
    }
}
