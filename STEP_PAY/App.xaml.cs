using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using STEP_PAY.Views;
using STEP_PAY.ViewModels;

namespace STEP_PAY
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

    }

    //public partial class App : Application
    //{
    //    protected override void OnStartup(StartupEventArgs e)
    //    {
    //        base.OnStartup(e);
    //        var mainView = new TestMainView()
    //        {
    //            DataContext = new TestMainViewModel(new NewsViewModel(), new SupportViewModel(), new ExpenceStatisticsViewModel())
    //        };

    //        MainWindow = mainView;
    //        MainWindow.Show();
    //    }
    //}

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IncomeWindow incomeWindow = new IncomeWindow() { DataContext = new ApplicationViewModel() }; ;

            WindowCosts WindowCosts = new WindowCosts() { DataContext = new ApplicationViewModel2() };
            incomeWindow.Show();
        }
    }

}
