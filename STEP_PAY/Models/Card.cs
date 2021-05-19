using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP_PAY.Models
{
    class Card
    {
        public int Id { get; set; }
        
        // Количество денег
        public int Money { get; set; }
        // Текущяя валюта
        public string Сurrency { get; set; }

        // Id пользователя
        public int UserId { get; set; }

        // Название Карты
        public string Title { get; set; }

        // Избранное или нет
        public bool Favorites { get; set; }

        // Номер Карты
        public string Number { get; set; }     

        // Пароль
        public int PinCode { get; set; }

        // Год Выпуска
        public int Year { get; set; }

        // Месяц Выпуска
        public int Month { get; set; }
    }
}