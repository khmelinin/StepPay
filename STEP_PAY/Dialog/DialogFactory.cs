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
