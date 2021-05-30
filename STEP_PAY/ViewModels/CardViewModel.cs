using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using STEP_PAY.Models;

namespace STEP_PAY.ViewModels
{
    public class CardViewModel : BindableBase
    {
        private List<Card> cards = new List<Card>();
        private string showCard = "Hidden";
        private string showCurrentCard1 = "Visible";
        private string showCurrentCard2 = "Visible";
        private string cardName;
        private string cardName2 = "Card 2";
        private string numberCard;
        private string dateExp;
        private string money;
        private string selectedCard;
        private Card favoriteCard1;
        private Card favoriteCard2;
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
        public List<Card> Cards
        {
            get
            {
                //List<Card> list = new List<Card>();
                //for (int i = 0; i < cards.Count; i++)
                //{
                //    list.Add(cards[i]);
                //    list[i].Money = Convert.ToInt32(list[i].Money);
                //}

                return cards;
            }
            set
            {
                SetProperty(ref cards, value);
            }
        }

        public CardViewModel()
        {
            AddCard();
            getInitialCard();
            GetCurrencies();
            SelectedInitialCard();
        }
        //private bool isUserHasCarts = false;

        private ICommand _showCardCommand;
        private ICommand _showCardCommand2;
        private ICommand _dropDownClosed;
        private ICommand _changeCurrencyCommand;

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
        }

        private void ChangeCurrency(double m1, double m2, string name)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Number == favoriteCard1.Number || cards[i].Number == favoriteCard2.Number)
                    continue;
                var money = cards[i].Money * m1 / m2;
                cards[i].Money = money;
                cards[i].Сurrency = name;
            }
        }

        private void ValueMoneyChange_Click()
        {
            var cardNumberSelected = cards.FirstOrDefault(c => c.Number == selectedCard);
            switch (indexValuta)
            {
                case 0:
                    ChangeCurrency(1, currencies[0].Rate, currencies[0].ShortName);
                    favoriteCard1.Money /= currencies[0].Rate;
                    favoriteCard2.Money /= currencies[0].Rate;
                    favoriteCard1.Сurrency = currencies[0].ShortName;
                    favoriteCard2.Сurrency = currencies[0].ShortName;
                    if (NumberCard == favoriteCard1.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard1.Money)) + " " + Convert.ToString(favoriteCard1.Сurrency);
                    }
                    else if (NumberCard == cardNumberSelected.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(cardNumberSelected.Money)) + " " + Convert.ToString(cardNumberSelected.Сurrency);
                    }
                    else
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard2.Money)) + " " + Convert.ToString(favoriteCard2.Сurrency);
                    }
                    break;
                case 1:
                    ChangeCurrency(currencies[0].Rate, currencies[1].Rate, currencies[1].ShortName);
                    favoriteCard1.Money *= currencies[0].Rate;
                    favoriteCard2.Money *= currencies[0].Rate;
                    favoriteCard1.Money /= currencies[1].Rate;
                    favoriteCard2.Money /= currencies[1].Rate;
                    favoriteCard1.Сurrency = currencies[1].ShortName;
                    favoriteCard2.Сurrency = currencies[1].ShortName;
                    if (NumberCard == favoriteCard1.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard1.Money)) + " " + Convert.ToString(favoriteCard1.Сurrency);
                    }
                    else if (NumberCard == cardNumberSelected.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(cardNumberSelected.Money)) + " " + Convert.ToString(cardNumberSelected.Сurrency);
                    }
                    else
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard2.Money)) + " " + Convert.ToString(favoriteCard2.Сurrency);
                    }
                    break;
                case 2:
                    ChangeCurrency(currencies[1].Rate, currencies[2].Rate, currencies[2].ShortName);
                    favoriteCard1.Money *= currencies[1].Rate;
                    favoriteCard2.Money *= currencies[1].Rate;
                    favoriteCard1.Money /= currencies[2].Rate;
                    favoriteCard2.Money /= currencies[2].Rate;
                    favoriteCard1.Сurrency = currencies[2].ShortName;
                    favoriteCard2.Сurrency = currencies[2].ShortName;
                    if (NumberCard == favoriteCard1.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard1.Money)) + " " + Convert.ToString(favoriteCard1.Сurrency);
                    }
                    else if (NumberCard == cardNumberSelected.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(cardNumberSelected.Money)) + " " + Convert.ToString(cardNumberSelected.Сurrency);
                    }
                    else
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard2.Money)) + " " + Convert.ToString(favoriteCard2.Сurrency);
                    }
                    break;
                case 3:
                    ChangeCurrency(currencies[2].Rate, currencies[3].Rate, currencies[3].ShortName);
                    favoriteCard1.Money *= currencies[2].Rate;
                    favoriteCard2.Money *= currencies[2].Rate;
                    favoriteCard1.Money /= currencies[3].Rate;
                    favoriteCard2.Money /= currencies[3].Rate;
                    favoriteCard1.Сurrency = currencies[3].ShortName;
                    favoriteCard2.Сurrency = currencies[3].ShortName;
                    if (NumberCard == favoriteCard1.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard1.Money)) + " " + Convert.ToString(favoriteCard1.Сurrency);
                    }
                    else if (NumberCard == cardNumberSelected.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(cardNumberSelected.Money)) + " " + Convert.ToString(cardNumberSelected.Сurrency);
                    }
                    else
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard2.Money)) + " " + Convert.ToString(favoriteCard2.Сurrency);
                    }
                    break;
                case 4:
                    ChangeCurrency(currencies[3].Rate, currencies[4].Rate, currencies[4].ShortName);
                    favoriteCard1.Money *= currencies[3].Rate;
                    favoriteCard2.Money *= currencies[3].Rate;
                    favoriteCard1.Money /= currencies[4].Rate;
                    favoriteCard2.Money /= currencies[4].Rate;
                    favoriteCard1.Сurrency = currencies[4].ShortName;
                    favoriteCard2.Сurrency = currencies[4].ShortName;
                    if (NumberCard == favoriteCard1.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard1.Money)) + " " + Convert.ToString(favoriteCard1.Сurrency);
                    }
                    else if (NumberCard == cardNumberSelected.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(cardNumberSelected.Money)) + " " + Convert.ToString(cardNumberSelected.Сurrency);
                    }
                    else
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard2.Money)) + " " + Convert.ToString(favoriteCard2.Сurrency);
                    }
                    break;
                case 5:
                    ChangeCurrency(currencies[4].Rate, currencies[5].Rate, currencies[5].ShortName);
                    favoriteCard1.Money *= currencies[4].Rate;
                    favoriteCard2.Money *= currencies[4].Rate;
                    favoriteCard1.Money /= currencies[5].Rate;
                    favoriteCard2.Money /= currencies[5].Rate;
                    favoriteCard1.Сurrency = currencies[5].ShortName;
                    favoriteCard2.Сurrency = currencies[5].ShortName;
                    if (NumberCard == favoriteCard1.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard1.Money)) + " " + Convert.ToString(favoriteCard1.Сurrency);
                    }
                    else if (NumberCard == cardNumberSelected.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(cardNumberSelected.Money)) + " " + Convert.ToString(cardNumberSelected.Сurrency);
                    }
                    else
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard2.Money)) + " " + Convert.ToString(favoriteCard2.Сurrency);
                    }
                    break;
                case 6:

                    ChangeCurrency(currencies[5].Rate, currencies[6].Rate, currencies[6].ShortName);
                    favoriteCard1.Money *= currencies[5].Rate;
                    favoriteCard2.Money *= currencies[5].Rate;
                    favoriteCard1.Money /= currencies[6].Rate;
                    favoriteCard2.Money /= currencies[6].Rate;
                    favoriteCard1.Сurrency = currencies[6].ShortName;
                    favoriteCard2.Сurrency = currencies[6].ShortName;
                    if (NumberCard == favoriteCard1.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard1.Money)) + " " + Convert.ToString(favoriteCard1.Сurrency);
                    }
                    else if (NumberCard == cardNumberSelected.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(cardNumberSelected.Money)) + " " + Convert.ToString(cardNumberSelected.Сurrency);
                    }
                    else
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard2.Money)) + " " + Convert.ToString(favoriteCard2.Сurrency);
                    }
                    break;
                case 7:
                    ChangeCurrency(currencies[6].Rate, 1, "UAH");
                    favoriteCard1.Money *= currencies[6].Rate;
                    favoriteCard2.Money *= currencies[6].Rate;
                    favoriteCard1.Сurrency = "UAH";
                    favoriteCard2.Сurrency = "UAH";
                    if (NumberCard == favoriteCard1.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard1.Money)) + " " + Convert.ToString(favoriteCard1.Сurrency);
                    }
                    else if (NumberCard == cardNumberSelected.Number)
                    {
                        Money = Convert.ToString(Convert.ToInt32(cardNumberSelected.Money)) + " " + Convert.ToString(cardNumberSelected.Сurrency);
                    }
                    else
                    {
                        Money = Convert.ToString(Convert.ToInt32(favoriteCard2.Money)) + " " + Convert.ToString(favoriteCard2.Сurrency);
                    }
                    indexValuta = -1;
                    break;
            }
            indexValuta++;
        }

        private void SelectedInitialCard()
        {
            SelectedCard = cards[0].Number;
        }

        private void getInitialCard()
        {
            cardName = cards[0].Title;
            cardName2 = cards[1].Title;
            numberCard = cards[0].Number;
            DateExp = cards[0].Month.ToString("00") + "/" + Convert.ToString(cards[0].Year);
            Money = Convert.ToString(Convert.ToInt32(cards[0].Money)) + " " + Convert.ToString(cards[0].Сurrency);
        }

        private void AddCard()
        {
            Card c1 = new Card();
            c1.Title = "Card 1";
            c1.Number = "0000-2525-2222-3333";
            c1.Month = 08;
            c1.Year = 23;
            c1.Сurrency = "UAH";
            c1.Money = 10000;
            Card c2 = new Card();
            c2.Title = "Card 2";
            c2.Money = 5000;
            c2.Number = "0000-2525-2222-4443";
            c2.Month = 10;
            c2.Year = 25;
            c2.Сurrency = "UAH";
            Card c3 = new Card();
            c3.Title = "Card 3";
            c3.Money = 9000;
            c3.Number = "1111-2525-2222-3333";
            c3.Month = 01;
            c3.Year = 22;
            c3.Сurrency = "UAH";
            cards.Add(c1);
            cards.Add(c2);
            cards.Add(c3);
            favoriteCard1 = c1;
            favoriteCard2 = c2;
        }

        public string SelectedCard { get => selectedCard; set => SetProperty(ref selectedCard, value); }


        public ICommand ShowCardCommand => _showCardCommand ?? (_showCardCommand = new DelegateCommand(
            () =>
            {
                if (ShowCard == "Hidden")
                {
                    ShowCard = "Visible";
                }
                else
                {
                    ShowCard = "Hidden";
                }
            }));

        public ICommand ShowCardCommand2 => _showCardCommand2 ?? (_showCardCommand2 = new DelegateCommand(
           () =>
           {
               if (CardName2 == favoriteCard1.Title)
               {
                   CardName2 = favoriteCard2.Title;
                   CardName = favoriteCard1.Title;
                   NumberCard = favoriteCard1.Number;
                   DateExp = favoriteCard1.Month.ToString("00") + "/" + Convert.ToString(favoriteCard1.Year);
                   Money = Convert.ToString(Convert.ToInt32(favoriteCard1.Money)) + " " + Convert.ToString(favoriteCard1.Сurrency);
               }
               else
               {
                   CardName2 = favoriteCard1.Title;
                   CardName = favoriteCard2.Title;
                   NumberCard = favoriteCard2.Number;
                   DateExp = favoriteCard2.Month.ToString("00") + "/" + Convert.ToString(favoriteCard2.Year);
                   Money = Convert.ToString(Convert.ToInt32(favoriteCard2.Money)) + " " + Convert.ToString(favoriteCard2.Сurrency);
               }

           }));


        public string ShowCard { get => showCard; set => SetProperty(ref showCard, value); }
        public string ShowCurrentCard { get => showCurrentCard1; set => SetProperty(ref showCurrentCard1, value); }
        public string ShowCurrentCard2 { get => showCurrentCard2; set => SetProperty(ref showCurrentCard2, value); }
        public string CardName { get => cardName; set => SetProperty(ref cardName, value); }
        public string NumberCard { get => numberCard; set => SetProperty(ref numberCard, value); }
        public string DateExp { get => dateExp; set => SetProperty(ref dateExp, value); }
        public string Money { get => money; set => SetProperty(ref money, value); }
        public string CardName2 { get => cardName2; set => SetProperty(ref cardName2, value); }



        public ICommand DropDownClosed => _dropDownClosed ?? (_dropDownClosed = new DelegateCommand<EventArgs>(
        (e) =>
        {
            var card = cards.FirstOrDefault(c => c.Number == SelectedCard);
            if (NumberCard == card.Number)
                return;
            if (CardName2 == card.Title)
            {
                if (CardName2 == favoriteCard1.Title)
                    CardName2 = favoriteCard2.Title;
                else
                    CardName2 = favoriteCard1.Title;

            }
            CardName = card.Title;
            NumberCard = card.Number;
            DateExp = card.Month.ToString("00") + "/" + Convert.ToString(card.Year);
            Money = Convert.ToString(Convert.ToInt32(card.Money)) + " " + Convert.ToString(card.Сurrency);
        }));

        public ICommand ChangeCurrencyCommand => _changeCurrencyCommand ?? (_changeCurrencyCommand = new DelegateCommand(() =>
        {
            ValueMoneyChange_Click();
        }));
    }
}
