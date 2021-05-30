using Prism.Commands;
using Prism.Mvvm;
using STEP_PAY.Dialog;
using STEP_PAY.Models;
using STEP_PAY.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace STEP_PAY.ViewModel
{
    class RegistrationViewModel : BindableBase, IRegister
    {
        private string firstname;
        private string lastname;
        private string email;
        private SecureString password;
        private SecureString confirmPassword;
        private string adress;
        private string toCollapsed = "Collapsed";
        private string toVisible = "Visible";
        private bool isLogin = true;

        private ICommand loginCommand;
        private ICommand registrationCommand;
        private ICommand gotoRegistrationCommand;
        private List<User> users = new List<User>();

        public RegistrationViewModel()
        {
            users.Add(new User()
            {
                Firstname = "user 1",
                Lastname = "lastname 1",
                Email = "user1@user.com",
                Adress = "Adress user 1",
                Password = new NetworkCredential("", "12345").SecurePassword
            });

            users.Add(new User()
            {
                Firstname = "user 2",
                Lastname = "lastname 2",
                Email = "user2@user.com",
                Adress = "Adress user 1",
                Password = new NetworkCredential("", "123456").SecurePassword
            });
        }

        public string Adress { get => adress; set => SetProperty(ref adress, value); }
        public SecureString ConfirmPassword { get => confirmPassword; set => SetProperty(ref confirmPassword, value); }
        public string Firstname { get => firstname; set => SetProperty(ref firstname, value); }
        public string Lastname { get => lastname; set => SetProperty(ref lastname, value); }
        public string Email { get => email; set => SetProperty(ref email, value); }
        public SecureString Password { get => password; set => SetProperty(ref password, value); }
        public string ToVisible { get => toVisible; set => SetProperty(ref toVisible, value); }
        public string ToCollapsed { get => toCollapsed; set => SetProperty(ref toCollapsed, value); }

        public ICommand LoginCommand => loginCommand ?? (loginCommand = new DelegateCommand(() =>
        {
            var passwordToString = new NetworkCredential(string.Empty, Password).Password;
            var currentUser = users.FirstOrDefault(u => (u.Email == Email) && ((new NetworkCredential(string.Empty, u.Password).Password) == passwordToString));
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(passwordToString))
            {
                if (currentUser == null)
                {
                    MessageBox.Show("User doesn't exist");
                }
                else
                {
                    var global = new CardViewModel();
                    DialogFactory.ShowAdminDialog(global);
                    
                }
            }
        }));
        public ICommand RegistrationCommand => registrationCommand ?? (registrationCommand = new DelegateCommand(() =>
        {
            if (isregistrationDataisValide())
            {
                var passwordToString = new NetworkCredential(string.Empty, Password).Password;
                var confirmPasswordToString = new NetworkCredential(string.Empty, ConfirmPassword).Password;
                if (passwordToString == confirmPasswordToString)
                {
                    users.Add(new User()
                    {
                        Firstname = Firstname,
                        Lastname = Lastname,
                        Email = Email,
                        Adress = Adress,
                        Password = Password
                    });
                }
                else
                {
                    MessageBox.Show("Password is not the same");
                }
            }
        }));

        public ICommand GotoRegistrationCommand => gotoRegistrationCommand ?? (gotoRegistrationCommand = new DelegateCommand(() =>
        {
            if (!isLogin)
            {
                ToCollapsed = "Collapsed";
                ToVisible = "Visible";
                IsLogin = true;
            }
            else
            {
                ToCollapsed = "Visible";
                ToVisible = "Collapsed";
                IsLogin = false;
            }
        }));

        public bool IsLogin { get => isLogin; set => SetProperty(ref isLogin, value); }

        public ObservableCollection<User> Registrations => new ObservableCollection<User>(users);

        private bool isregistrationDataisValide()
        {
            var passwordToString = new NetworkCredential(string.Empty, Password).Password;
            if (
                !string.IsNullOrEmpty(Firstname) &&
                !string.IsNullOrEmpty(Lastname) &&
                !string.IsNullOrEmpty(Email) &&
                !string.IsNullOrEmpty(passwordToString) &&
                !string.IsNullOrEmpty(Adress)
                )
                return true;
            return false;
        }
    }
}
