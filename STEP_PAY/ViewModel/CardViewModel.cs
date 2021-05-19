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

        private ICommand _showCardCommand;

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


        public string ShowCard { get => showCard; set => SetProperty(ref showCard, value); }
    }
}
