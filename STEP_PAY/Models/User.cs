using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP_PAY.Models
{
    class User
    {
        public int Id { get; set; }

        // Имя
        public string Name { get; set; }

        // Дата Рождения
        public DateTime Birthday { get; set; }

        // Номер Телефона
        public int PhoneNumber { get; set; }

        // Почта
        public string Email { get; set; }

        

    }
}