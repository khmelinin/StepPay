using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace STEP_PAY.ViewModels
{
    public class NewsViewModel : INewsViewModel
    {
       // private void Application_NavigationFailed(object sender,
       //System.Windows.Navigation.NavigationFailedEventArgs e)
       // {
       //     if (e.Exception is System.Net.WebException)
       //     {
       //         MessageBox.Show("Сайт " + e.Uri.ToString() + " не доступен :(");
       //         // Нейтрализовать ошибку, чтобы приложение продолжило свою работу
       //         e.Handled = true;
       //     }
       // }
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
