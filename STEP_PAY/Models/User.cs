using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP_PAY.Models
{
    class User
    {
        public User(List<Card> cards)
        {
            Cards = cards;
        }

        public User(int id, int phoneNumber, string name, string email, DateTime birthday)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            Name = name;
            Email = email;
            Birthday = birthday;
        }

        /////////
        // INT //
        /////////
        public int Id { get; set; }

        // Номер Телефона
        public int PhoneNumber { get; set; }

        ////////////
        // String //
        ////////////

        // Имя
        public string Name { get; set; }

        // Почта
        public string Email { get; set; }


        //////////////
        // DateTime //
        //////////////

        // Дата Рождения
        public DateTime Birthday { get; set; }



        ////////////
        //  List  //
        ////////////

        // Карточки пользователя
        public List<Card> Cards { get; set; }



        ///////////////
        // Functions //
        ///////////////
        

        // Добавить карту
        public void AddCard(Card card)
        {

        }
        // Удалить Карту
        public void RemoveCard(Card card)
        {

        }
       
        

    }
}