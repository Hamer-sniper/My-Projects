using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsoleApp
{
    /// <summary>
    /// Структура "Сотрудники"
    /// </summary>
    struct Employes
    {
        #region Поля
        /// <summary>
        /// Поле "ID"
        /// </summary>
        private string iD;

        /// <summary>
        /// Поле "Дата и время заметки"
        /// </summary>
        private string dateAndTime;

        /// <summary>
        /// Поле "ФИО"
        /// </summary>
        private string name;

        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        private string age;

        /// <summary>
        /// Поле "Рост"
        /// </summary>
        private string hight;

        /// <summary>
        /// Поле "Дата рождения"
        /// </summary>
        private string dayOfBurth;

        /// <summary>
        /// Поле "Место рождения"
        /// </summary>
        private string placeOfBurn;
        #endregion

        #region Свойства        
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get { return this.iD; } set { this.iD = value; } }

        /// <summary>
        /// Дата и время заметки
        /// </summary>
        public string DateAndTime { get { return this.dateAndTime; } set { this.dateAndTime = value; } }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get { return this.name; } set { this.name = value; } }

        /// <summary>
        /// Возраст
        /// </summary>
        public string Age { get { return this.age; } set { this.age = value; } }

        /// <summary>
        /// Рост
        /// </summary>
        public string Hight { get { return this.hight; } set { this.hight = value; } }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string DayOfBurth { get { return this.dayOfBurth; } set { this.dayOfBurth = value; } }

        /// <summary>
        /// Место рождения
        /// </summary>
        public string PlaceOfBurn { get { return this.placeOfBurn; } set { this.placeOfBurn = value; } }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор со всеми параметрами
        /// </summary> 
        /// <param name="ID">ID</param>
        /// <param name="DateAndTime">Дата и время</param>
        /// <param name="Name">ФИО</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Hight">Рост</param>
        /// <param name="DayOfBurth">Дата рождения</param>
        /// <param name="PlaceOfBurn">Место рождения</param>
        public Employes(string ID, string DateAndTime, string Name, string Age, string Hight, string DayOfBurth, string PlaceOfBurn)
        {
            this.iD = ID;
            this.dateAndTime = DateAndTime;
            this.name = Name;
            this.age = Age;
            this.hight = Hight;
            this.dayOfBurth = DayOfBurth;
            this.placeOfBurn = PlaceOfBurn;
        }

        /// <summary>
        /// Конструктор с подстановкой текущей даты/времени и ID
        /// </summary>          
        /// <param name="Name">ФИО</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Hight">Рост</param>
        /// <param name="DayOfBurth">Дата рождения</param>
        /// <param name="PlaceOfBurn">Место рождения</param>
        public Employes(string Name, string Age, string Hight, string DayOfBurth, string PlaceOfBurn):
            this("", "", Name, Age, Hight, DayOfBurth, PlaceOfBurn)
        {
            string stringGuid = Guid.NewGuid().ToString();
            this.iD = stringGuid.Substring(0, 8);
            //this.dateAndTime = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}";            
            this.dateAndTime = $"{DateTime.Now:g}";
        }
        #endregion

        #region Методы
        /// <summary>
        /// Вывод информации в консоль
        /// </summary>
        /// <returns>Строка с информацией о сотруднике</returns>
        public string Print()
        {           
            return $"{this.ID,9}{this.DateAndTime,17}{this.Name,35}{this.Age,8}{this.Hight,5}{this.DayOfBurth,14}{this.PlaceOfBurn,20}";
        }
        #endregion
    }
}
