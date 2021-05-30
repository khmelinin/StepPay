using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STEP_PAY.Views
{
    /// <summary>
    /// Interaction logic for PasswordUser.xaml
    /// </summary>
    public partial class PasswordUser : UserControl
    {
        public PasswordUser()
        {
            InitializeComponent();
            pwdBox.PasswordChanged += (sender, args) => {
                PasswordText = ((PasswordBox)sender).SecurePassword;
            };
        }

        public SecureString PasswordText
        {
            get { return (SecureString)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }


        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("PasswordText", typeof(SecureString), typeof(PasswordUser),
                new PropertyMetadata(default(SecureString)));
    }
}
