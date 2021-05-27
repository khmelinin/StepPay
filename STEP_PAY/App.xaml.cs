﻿using STEP_PAY.View;
using STEP_PAY.ViewModel;
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
            var mainView = new MainView()
            {
                DataContext =  /*new SupportViewModel() */new CardViewModel()
            };

            MainWindow = mainView;
            MainWindow.Show();
        }
    }
}
