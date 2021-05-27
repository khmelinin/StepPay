using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP_PAY.Models
{
    class Account
    {
        /////////
        // INT //
        /////////
        
        public int Id { get; set; }

        // Id Пользователя
        public int UserId { get; set; }


        ////////////
        // String //
        ////////////
        
        // Логин

        public string Login { get; set; }
        // Пароль
        public string Password { get; set; }
       

    }
}