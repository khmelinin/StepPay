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
using TransHistory.ViewModels;

namespace STEP_PAY.Views
{
    /// <summary>
    /// Interaction logic for TransHistory.xaml
    /// </summary>
    public partial class TransHistory : Window
    {
        public TransHistory()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new HistoryViewModel();
        }
    }
}
