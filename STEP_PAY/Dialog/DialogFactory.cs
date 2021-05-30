using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STEP_PAY.Views;
using STEP_PAY.ViewModels;

namespace STEP_PAY.Dialog
{
    class DialogFactory
    {
        public static void ShowAdminDialog(CardViewModel ca /*Andrii тут буде м модел для головної сторінки*/)
        {
            GlobalPage global = new GlobalPage() { DataContext = ca };
            global.Show();
        }
    }
}
