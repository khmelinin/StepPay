using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TransHistory.Models;

namespace TransHistory.ViewModels
{
    public class HistoryViewModel : ObservableCollection<Transactions>
    {
        public HistoryViewModel()
        {
            addTransaction();
            addCommand = new RelayCommand(addTransaction);
            deleteCommand = new RelayCommand<int>(deleteTransaction);
        }

        public ICommand addCommand { get; set; }
        public ICommand deleteCommand { get; set; }

        public void deleteTransaction(int index)
        {
            RemoveAt(index);
        }

        public void addTransaction()
        {
            var newTrans = new Transactions
            {
                Receiver = "Новый",
                Sum = "",
                Time = "",
                Purpose = ""
            };
            Add(newTrans);
        }
    }
}
