using Newtonsoft.Json;
using STEP_PAY.Models;
using STEP_PAY.ViewModels;
using STEP_PAY.Views;
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
        public MainWindow()
        {
            InitializeComponent();
            DataContext =  /*new SupportViewModel() */new CardViewModel();
        }
        private async Task<List<Models.Currency>> GetCurrencies()
        {
            HttpClient client = new HttpClient();
            List<string> allowedCurrencies = new List<string> { "USD", "EUR", "RUB" };
            var res = await client.GetAsync(Globals.CurrenciesUrl);
            var content = res.Content;
            var allCurrencies = JsonConvert.DeserializeObject<List<Models.Currency>>(await content.ReadAsStringAsync());

            var currencies = from currency in allCurrencies
                             where allowedCurrencies.Find((shortName) => shortName == currency.ShortName) != null
                             select currency;

            return currencies.ToList();
        }

        private void button_profile_Click(object sender, RoutedEventArgs e)
        {
            var mainView = new TestMainView()
            {
                DataContext = new TestMainViewModel(new NewsViewModel(), new SupportViewModel(), new ExpenceStatisticsViewModel())
            };

            mainView.Show();

            //TestMainView test = new TestMainView();
            //test.Show();
        }

        private void button_trans_history_Click(object sender, RoutedEventArgs e)
        {
            var th = new STEP_PAY.Views.TransHistory();
            th.Show();
        }
    }
}
