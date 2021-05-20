using Newtonsoft.Json;
using STEP_PAY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STEP_PAY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public object Globals { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void textbox_exchange_rates_Click(object sender, RoutedEventArgs e)
        {

        }

        private async Task<List<Currency>> GetCurrencies()
        {
            HttpClient client = new HttpClient();
            List<string> allowedCurrencies = new List<string> { "USD", "EUR", "RUB" };
            var res = await client.GetAsync("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json");
            var content = res.Content;
            var allCurrencies = JsonConvert.DeserializeObject<List<Currency>>(await content.ReadAsStringAsync());

            var currencies = from currency in allCurrencies
                             where allowedCurrencies.Find((shortName) => shortName == currency.ShortName) != null
                             select currency;

            return currencies.ToList();
        }
    }
}
