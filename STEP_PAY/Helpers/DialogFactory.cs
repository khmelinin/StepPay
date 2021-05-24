using STEP_PAY.ViewModels;
using STEP_PAY.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP_PAY.Helpers
{
    public static class DialogFactory
    {
        public static void ShowLoginView(LoginViewModel vm)
        {
            LoginView view = new LoginView() { DataContext = vm };
            view.Show();
        }
    }
}
