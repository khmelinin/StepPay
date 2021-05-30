using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STEP_PAY.Models;

namespace STEP_PAY.ViewModel
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
