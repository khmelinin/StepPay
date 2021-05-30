using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP_PAY.ViewModels
{
    class MainViewModel
    {
        private IRegister registration;

        public MainViewModel(IRegister r)
        {
            registration = r;
        }

        public IRegister Register => registration;
    }
}
