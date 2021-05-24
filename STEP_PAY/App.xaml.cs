using STEP_PAY.ViewModels;
using STEP_PAY.Views;
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
            MainWindow = new MainView() { DataContext = new MainViewModel() };
            MainWindow.Show();
        }
    }
}
