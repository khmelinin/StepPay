using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace STEP_PAY.ViewModel
{
    public class CardViewModel : BindableBase
    {
        private string showCard = "Hidden";
        private string showCurrentCard1 = "Visible";
        private string showCurrentCard2 = "Visible";
        private string cardName = "Card 1";
        private string cardName2 = "Card 2";
        private string numberCard = "4525-4525-4525-4525";
        private string dateExp = "10/21";
        private string money = "200 UAH";
        private bool isCardChanged = false;

        //private bool isUserHasCarts = false;


        private ICommand _showCardCommand;
        private ICommand _showCardCommand2;

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
               if (!IsCardChanged)
               {
                   CardName2 = "Card 1";
                   NumberCard = "5689-4789-5689-0000";
                   DateExp = "12/25";
                   Money = "750 UAH";
                   CardName = "Card 2";
                   IsCardChanged = true;

               }
               else
               {
                  CardName = "Card 1";
                  CardName2 = "Card 2";
                  NumberCard = "4525-4525-4525-4525";
                  DateExp = "10/21";
                  Money = "200 UAH";
                  IsCardChanged = false;
   
               }
           }));


        public string ShowCard { get => showCard; set => SetProperty(ref showCard, value); }
        public string ShowCurrentCard { get => showCurrentCard1; set => SetProperty(ref showCurrentCard1, value); }
        public string ShowCurrentCard2 { get => showCurrentCard2; set => SetProperty(ref showCurrentCard2, value); }
        public string CardName { get => cardName; set => SetProperty(ref cardName, value); }
        public string NumberCard { get => numberCard; set => SetProperty(ref numberCard, value); }
        public string DateExp { get => dateExp; set => SetProperty(ref dateExp, value); }
        public string Money { get => money; set => SetProperty(ref money, value); }
        public string CardName2 { get => cardName2; set => SetProperty(ref cardName2 , value); }
        public bool IsCardChanged { get => isCardChanged; set => SetProperty(ref isCardChanged, value); }
    }
}
