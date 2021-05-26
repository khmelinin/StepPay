using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;


namespace STEP_PAY.ViewModels
{
    class TestMainViewModel : BindableBase, ITestMainViewModel
    {
        private INewsViewModel news;
        private ISupportViewModel support;
        private IExpenceStatisticsViewModel expence;

        public TestMainViewModel(INewsViewModel nw, ISupportViewModel sw, IExpenceStatisticsViewModel ew)
        {
            news = nw;
            support = sw;
            expence = ew;
        }

        public INewsViewModel News => news;
        public ISupportViewModel Support => support;
        public IExpenceStatisticsViewModel Expence => expence;
    }
}
