using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Prism.Mvvm;
using STEP_PAY.Models;
using Prism.Commands;
using System.Windows.Input;
using STEP_PAY.Helpers;

namespace STEP_PAY.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private List<Currency> currencies = new List<Currency>();
        private bool closeDialog = false;
        public List<Currency> Currencies
        {
            get => currencies;
            set
            {
                SetProperty(ref currencies, value);
            }
        }
        // actual user goes here
        public User User { get; } = new User();
        public bool CloseDialog 
        {
            get => closeDialog;
            set
            {
                SetProperty(ref closeDialog, value);
            }
        }
        public ICommand ExitCommand { get; }

        public MainViewModel()
        {
            GetCurrencies();
            ExitCommand = new DelegateCommand(() =>
            {
                DialogFactory.ShowLoginView(new LoginViewModel());
                CloseDialog = true;
            });
        }

        private async Task GetCurrencies()
        {
            HttpClient client = new HttpClient();
            List<string> allowedCurrencies = new List<string> { "USD", "EUR", "RUB" };
            var res = await client.GetAsync(Globals.CurrenciesUrl);
            var content = res.Content;
            var allCurrencies = JsonConvert.DeserializeObject<List<Currency>>(await content.ReadAsStringAsync());
            var currencies = from currency in allCurrencies
                             where allowedCurrencies.Find((str) => str == currency.ShortName) != null
                             select currency;

            Currencies = new List<Currency>(currencies);
        }
    }
}
