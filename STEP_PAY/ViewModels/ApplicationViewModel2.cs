using STEP_PAY.Models;
using STEP_PAY.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace STEP_PAY.ViewModels
{
    public class ApplicationViewModel2 : BindableBase
    {
        private decimal allMoney = 0;
        private ICommand editEndingCommand;
        private ICommand deleteCommand;
        private Expenses selectedItem;
        private string visibility = "Visibility";
        private ObservableCollection<ExpensePercentage> records;

        //private ObservableCollection<Expens> records;
        //private ObservableCollection<ExpensePercentage> records;
        //public static List<TableClass> tableClassList = new List<TableClass>
        //   {
        //    new TableClass {Title="Продукты", Money=100,Percent = 0 },
        //    new TableClass {Title="Техника", Money=267 , Percent = 0},
        //    new TableClass {Title="Путешествия",  Money=588, Percent = 0},
        //    new TableClass {Title="Транспорт", Money=999,Percent = 0 },
        //    new TableClass {Title="Еда", Money=300 ,Percent = 0},
        //    new TableClass {Title="Кафе",  Money=350 ,Percent = 0}
        //   };

        public Expenses SelectedItem
        {
            get => selectedItem;
            set
            {
                SetProperty(ref selectedItem, value);
            }
        }

        //public observablecollection<Expens> Records
        //{
        //    get { return records; }
        //    set => setproperty(ref records, value);
        //}
        public ObservableCollection<ExpensePercentage> Records
        {
            get => records;
            set
            {
                SetProperty(ref records, value);
            }
        }


        public ICommand addCommand { get; set; }
        public ICommand EditEndingCommand => editEndingCommand ?? (editEndingCommand = new DelegateCommand<DataGridRowEditEndingEventArgs>(async e => {

            if (e.EditAction == DataGridEditAction.Cancel)
            {
                e.Cancel = true;
                return;
            }

            var expensePercentage = e.Row.Item as ExpensePercentage;
            var expense = new Expenses() { Id = expensePercentage.Id, CardId = CardId, Cards = expensePercentage.Cards, Money = expensePercentage.Money, Title = expensePercentage.Title };

            using (var db = new STEP_PAYEntities())
            {
                if (e.Row.IsNewItem)
                {
                    db.Expenses.Add(expense);
                    //records.Add(expensePercentage);
                }
                else
                {
                    db.Expenses.Attach(expense);
                    db.Entry(expense).State = System.Data.Entity.EntityState.Modified;
                }
                await db.SaveChangesAsync();
            }
            Recount();
            //if (Count < Records.Count)
            //{
            //    Count++;
            //    tableClassList.Add(tableClass);
            //}
            //Console.WriteLine(tableClassList.Count);
            //RaisePropertyChanged(nameof(Records));
            //else
            //{
            //    tableClassList.
            //}
        }));

        public string Visibility { get => visibility; set => SetProperty(ref visibility, value); }
        private const int CardId = 1;

        public ApplicationViewModel2()
        {
            //addTransaction();
            //addCommand = new RelayCommand(addTransaction);
            using (var db = new STEP_PAYEntities())
            {
                var expensesForUser = from Expenses in db.Expenses
                                      where Expenses.CardId == CardId && Expenses.Money < 0
                                      select new ExpensePercentage { Id = Expenses.Id, CardId = Expenses.CardId, Cards = Expenses.Cards, Money = Expenses.Money, Title = Expenses.Title };
                this.Records = new ObservableCollection<ExpensePercentage>(expensesForUser);
            }
            Recount();
            //for (int i = 0; i < vm.Records.Count; i++)
            //{
            //    AllMoney += vm.Records[i].Money;
            //}
            //vm.AllMoney = AllMoney;
            //for (int i = 0; i < vm.Records.Count; i++)
            //{th
            //    vm.Records[i].Percent = Math.Round(vm.Records[i].Money * 100 / AllMoney, 2);

            //}

            //table.Percent = Math.Round(vm.Records[vm.Records.Count - 1].Money * 100 / AllMoney, 2);





        }
        private void Recount()
        {
            for (int i = 0; i < Records.Count; i++)
            {
                allMoney += this.Records[i].Money;
            }
            Console.WriteLine(allMoney);
            for (int i = 0; i < Records.Count; i++)
            {
                Records[i].Percent = Math.Round((Records[i].Money) * 100 / allMoney, 2);
            }
            RaisePropertyChanged(nameof(Records));
            //MainWindow main = new MainWindow();
            //main.Show();
        }
        public void addTransaction()
        {
            //AddWindow wind = new AddWindow();
            //Visibility = "Hidden";
            //wind.ShowDialog();

        }
      


        //private void phonesGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        //{

        //    this.Visibility = Visibility.Hidden;
        //    wind.ShowDialog();
        //    this.Close();






        //}

    }
}

