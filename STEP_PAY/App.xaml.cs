using STEP_PAY.Views;
using STEP_PAY.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace STEP_PAY
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainView()
            {
                DataContext = new MainViewModel(new RegistrationViewModel())
            };

            MainWindow.Show();
        }
    }
}
