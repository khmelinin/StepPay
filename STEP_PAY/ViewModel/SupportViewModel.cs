using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace STEP_PAY.ViewModel
{
    public class SupportViewModel : BindableBase
    {
        private string visible = "Visible";
        private string hidden = "Hidden";
        private string textBoxValidation = "Hidden";
        private string textBoxContent;

        private ICommand _showSupportBoxCommand;
        private ICommand _sendFeedBackCommand;

        public ICommand ShowSupportBoxCommand => _showSupportBoxCommand ?? (_showSupportBoxCommand = new DelegateCommand(
            () =>
            {
                if (Visible == "Hidden")
                {
                    Visible = "Visible";
                    Hidden = "Hidden";
                }
                else
                {
                    Visible = "Hidden";
                    Hidden = "Visible";
                }
            }));


        public ICommand SendFeedbackCommand => _sendFeedBackCommand ?? (_sendFeedBackCommand = new DelegateCommand(
           () =>
           {
               if(string.IsNullOrEmpty(textBoxContent) && string.IsNullOrEmpty(textBoxContent))
               {
                   TextBoxValidation = "Visible";
               }
               else
               {
                   MessageBox.Show($"{TextBoxContent}");
                   TextBoxContent = string.Empty;

               }
           }));



        public string Visible { get => visible; set => SetProperty(ref visible, value); }
        public string Hidden { get => hidden; set => SetProperty(ref hidden, value); }
        public string TextBoxValidation { get => textBoxValidation; set => SetProperty(ref textBoxValidation, value); }
        public string TextBoxContent { get => textBoxContent; set => SetProperty(ref textBoxContent, value); }
    }
}
