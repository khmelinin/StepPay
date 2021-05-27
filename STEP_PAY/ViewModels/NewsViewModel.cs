using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
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

namespace STEP_PAY.ViewModels
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
    public class NewsViewModel : BindableBase, INewsViewModel
    {
        static int indexValuta = 0;
        private List<Currency> currencies = new List<Currency>();
        public List<Currency> Currencies
        {
            get => currencies;
            set
            {
                SetProperty(ref currencies, value);
            }
        }

        private double money = 100;
        private string valueMoneyString = "";
        public string ValueMoney
        {
            get => valueMoneyString;
            set
            {
                SetProperty(ref valueMoneyString, value);
            }
        }
        private void ValueMoneyChange_Click()
        {
            switch(indexValuta)
            {
                case 0:
                    money /= currencies[0].Rate;
                    ValueMoney = Convert.ToString(Math.Round(money, 2)) + " " + currencies[0].ShortName;
                    break;
                case 1:
                    money *= currencies[0].Rate;
                    money /= currencies[1].Rate;
                    ValueMoney = Convert.ToString(Math.Round(money, 2)) + " " + currencies[1].ShortName;
                    break;
                case 2:
                    money *= currencies[1].Rate;
                    money /= currencies[2].Rate;
                    ValueMoney = Convert.ToString(Math.Round(money, 2)) + " " + currencies[2].ShortName;
                    break;
                case 3:
                    money *= currencies[2].Rate;
                    money /= currencies[3].Rate;
                    ValueMoney = Convert.ToString(Math.Round(money, 2)) + " " + currencies[3].ShortName;
                    break;
                case 4:
                    money *= currencies[3].Rate;
                    money /= currencies[4].Rate;
                    ValueMoney = Convert.ToString(Math.Round(money, 2)) + " " + currencies[4].ShortName;
                    break;
                case 5:
                    money *= currencies[4].Rate;
                    money /= currencies[5].Rate;
                    ValueMoney = Convert.ToString(Math.Round(money, 2)) + " " + currencies[5].ShortName;
                    break;
                case 6:
                    money *= currencies[5].Rate;
                    money /= currencies[6].Rate;
                    ValueMoney = Convert.ToString(Math.Round(money, 2)) + " " + currencies[6].ShortName;
                    break;
                case 7:
                    money *= currencies[6].Rate;
                    ValueMoney = Convert.ToString(Math.Round(money, 2)) + " UAH";
                    indexValuta = -1;
                    break;
            }
            indexValuta++;
        }
        public ICommand ValueMoneyChange_Command => new DelegateCommand(ValueMoneyChange_Click);
        public NewsViewModel()
        {
            GetCurrencies();
            valueMoneyString = Convert.ToString(money) + " UAH";
        }

        private async Task GetCurrencies()
        {
            HttpClient client = new HttpClient();
            List<string> allowedCurrencies = new List<string> { "USD", "EUR", "RUB", "CZK", "CHF", "GBP", "PLN" };
            var res = await client.GetAsync(Globals.CurrenciesUrl);
            var content = res.Content;
            var allCurrencies = JsonConvert.DeserializeObject<List<Currency>>(await content.ReadAsStringAsync());
            var currencies = from currency in allCurrencies
                             where allowedCurrencies.Find((str) => str == currency.ShortName) != null
                             select currency;

            Currencies = new List<Currency>(currencies);
            Console.WriteLine(currencies.Count());
        }
        private void hyperlink_Click1()
        {
            try { Process.Start("https://www.pravda.com.ua/news/"); }
            catch (Exception) { throw; }
        }
        private void hyperlink_Click2()
        {
            try { Process.Start("https://tsn.ua/ru/vypusky/tsn_tyzhden"); }
            catch (Exception) { throw; }
        }
        private void hyperlink_Click3()
        {
            try { Process.Start("https://www.ukr.net/ua/news/za_rubezhom.html"); } 
            catch (Exception) { throw; }
        }
        private void hyperlink_Click4()
        {
            try { Process.Start("https://bank.gov.ua/ua/markets/exchangerate-chart"); }
            catch (Exception) { throw; }
        }
        private void hyperlink_Click5()
        {
            try { Process.Start("https://kof.com.ua/articles/economics/"); }
            catch (Exception) { throw; }
        }
        private void hyperlink_Click6()
        {
            try { Process.Start("https://1prime.ru/trend/bitcoins/"); }
            catch (Exception) { throw; }
        }
        public ICommand Hyperlink_Command1 => new DelegateCommand(hyperlink_Click1);
        public ICommand Hyperlink_Command2 => new DelegateCommand(hyperlink_Click2);
        public ICommand Hyperlink_Command3 => new DelegateCommand(hyperlink_Click3);
        public ICommand Hyperlink_Command4 => new DelegateCommand(hyperlink_Click4);
        public ICommand Hyperlink_Command5 => new DelegateCommand(hyperlink_Click5);
        public ICommand Hyperlink_Command6 => new DelegateCommand(hyperlink_Click6);
    }
}
