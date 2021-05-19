using STEP_PAY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task<List<Currency>> GetCurrencies()
        {
            HttpClient client = new HttpClient();
            List<string> allowedCurrencies = new List<string> { "USD", "EUR", "RUB" };
            var res = await client.GetAsync(Globals.CurrenciesUrl);

            if (!res.IsSuccessStatusCode) throw new Exception("Couldn\'t receive currencies.");

            var content = res.Content;
            var currencies = from currency in JsonSerializer.DeserializeAsync<List<Currency>>(await content.ReadAsStreamAsync()).Result
                             where allowedCurrencies.Find((str) => str == currency.cc) != null
                             select currency;

            return currencies.ToList();
        }
    }
}
