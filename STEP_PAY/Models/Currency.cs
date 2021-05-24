using Newtonsoft.Json;

namespace STEP_PAY.Models
{
    public class Currency
    {
        [JsonProperty(PropertyName = "r030")]
        public int CurrencyCode { get; set; }
        [JsonProperty(PropertyName = "txt")]
        public string FullName { get; set; }
        [JsonProperty(PropertyName = "rate")]
        public double Rate { get; set; }
        [JsonProperty(PropertyName = "cc")]
        public string ShortName { get; set; }
        [JsonProperty(PropertyName = "exchangedate")]
        public string ExchangeDate { get; set; }
    }
}
