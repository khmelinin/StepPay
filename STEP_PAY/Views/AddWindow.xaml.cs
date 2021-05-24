using STEP_PAY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace STEP_PAY.Views
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            MainWindow main = new MainWindow();
            TableClass table = new TableClass();
            double AllMoney = 0;
            table.Title = this.Title.Text;
            table.Money = Convert.ToDouble(this.Money.Text);

           

            main.tableClassList.Add(table);

            for (int i = 0; i <  main.tableClassList.Count; i++)
            {
                AllMoney += main.tableClassList[i].Money;
            }
            main.AllMoney = AllMoney;
            for (int i = 0; i < main.tableClassList.Count; i++)
            {
                main.tableClassList[i].Percent = Math.Round(main.tableClassList[i].Money * 100 / AllMoney, 2);

            }
            table.Percent = Math.Round(main.tableClassList[main.tableClassList.Count-1].Money * 100 / AllMoney, 2);
            
            main.Show();
            this.Visibility = Visibility.Collapsed;
        }
    }
}
