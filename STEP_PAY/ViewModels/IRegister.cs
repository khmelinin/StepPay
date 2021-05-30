using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STEP_PAY.Models;

namespace STEP_PAY.ViewModels
{
    interface IRegister
    {
        ObservableCollection<User> Registrations { get; }
    }
}
