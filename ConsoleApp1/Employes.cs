using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsoleApp
{
    struct Employes
    {
        //ID
        public string ID { get; set; }
        //Дата и время добавления записи
        public string DateAndTime { get; set; }
        //Ф.И.О.
        public string Name { get; set; }
        //Возраст
        public string Age { get; set; }
        //Рост
        public string Hight { get; set; }
        //Дата рождения
        public string DayOfBurth { get; set; }
        //Место рождения
        public string PlaceOfBurn { get; set; }

        /// <summary>
        /// Конструктор с подстановкой текущей даты
        /// </summary>               
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="hight"></param>
        /// <param name="dayOfBurth"></param>
        /// <param name="placeOfBurn"></param>
        public Employes(string name, string age, string hight, string dayOfBurth, string placeOfBurn)
        {
            this.ID = Guid.NewGuid().ToString();
            this.DateAndTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            this.Name = name;
            this.Age = age;
            this.Hight = hight;
            this.DayOfBurth = dayOfBurth;
            this.PlaceOfBurn = placeOfBurn;
        }
    }
}
