using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace STEP_PAY.ViewModels
{
    public class SupportViewModel : BindableBase
    {
        private string visible = "Visible";
        private string hidden = "Hidden";
        private string textBoxValidation = "Hidden";
        private string textBoxContent;
        private string emailText;

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

        private void OnOpenHttpLinkCommand()
        {
            try
            {
                Process.Start("https://www.cardorelngassaki.com/");
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ICommand OpenLinkCommand => new DelegateCommand(OnOpenHttpLinkCommand);


        public ICommand SendFeedbackCommand => _sendFeedBackCommand ?? (_sendFeedBackCommand = new DelegateCommand(
           () =>
           {
               if (string.IsNullOrEmpty(textBoxContent)
               && string.IsNullOrEmpty(textBoxContent)
               && string.IsNullOrEmpty(emailText)
               && string.IsNullOrWhiteSpace(emailText))
               {
                   TextBoxValidation = "Visible";
               }
               else
               {
                   SendMessage(EmailText, TextBoxContent);
                   TextBoxContent = string.Empty;
                   MessageBox.Show("Спасибо, свяжемся с вами в ближайшее время !");

               }
           }));

        void SendMessage(string email, string body)
        {
            var toAddress = new MailAddress("cardorelngassaki@gmail.com");
            var fromAddress = new MailAddress(email);
            var smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "123456"),
                TargetName = "STARTTLS/smtp.gmail.com",
                Timeout = 20000
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "Feedback",
                Body = body
            })
            {
                //smtp.Send(message);
            }
        }



        public string Visible { get => visible; set => SetProperty(ref visible, value); }
        public string Hidden { get => hidden; set => SetProperty(ref hidden, value); }
        public string TextBoxValidation { get => textBoxValidation; set => SetProperty(ref textBoxValidation, value); }
        public string TextBoxContent { get => textBoxContent; set => SetProperty(ref textBoxContent, value); }
        public string EmailText { get => emailText; set => SetProperty(ref emailText, value); }
    }
}
