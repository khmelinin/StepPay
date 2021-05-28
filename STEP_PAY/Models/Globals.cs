using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using Newtonsoft.Json;

namespace STEP_PAY.Models
{
    internal static class Globals
    {
        public static string CurrenciesUrl = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
    }

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
