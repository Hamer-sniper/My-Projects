using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace HelloWorldConsoleApp
{
    public class Notebook
    {
        #region Свойства
        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Номер дома
        /// </summary>
        public string House { get; set; }
        /// <summary>
        /// Номер квартиры
        /// </summary>
        public string Flat { get; set; }
        /// <summary>
        /// Мобильный телефон
        /// </summary>
        public string MobilePhoneNumber { get; set; }
        /// <summary>
        /// Домашний телефон
        /// </summary>
        public string PhoneNumber { get; set; }
        #endregion


        #region Методы      
        /// <summary>
        /// Добавить данные из консоли и записать в xml
        /// </summary>
        public void AddFromUser(string path)
        {
            Console.Write($"{"Введите ФИО: ",28}");
            Fio = Console.ReadLine();
            Console.Write($"{"Введите Улицу: ",28}");
            Street = Console.ReadLine();
            Console.Write($"{"Введите Номер дома: ",28}");
            House = Console.ReadLine();
            Console.Write($"{"Введите Номер Квартиры: ",28}");
            Flat = Console.ReadLine();
            Console.Write($"{"Введите Мобильный телефон: ",28}");
            MobilePhoneNumber = Console.ReadLine();
            Console.Write($"{"Введите Домашний телефон: ",28}");
            PhoneNumber = Console.ReadLine();

            AddToXml(Fio, Street, House, Flat, MobilePhoneNumber, PhoneNumber, path);
        }

        /// <summary>
        /// Заполнение xml
        /// </summary>
        /// <param name="pName">ФИО</param>
        /// <param name="pStreet">Улица</param>
        /// <param name="pHouseNumber">Номер дома</param> 
        /// <param name="pFlatNumber">Номер квартиры</param>
        /// <param name="pMobilePhone">Мобильный телефон</param>
        /// <param name="pFlatPhone">Домашний телефон</param>
        /// <param name="path">Путь к файлу</param>
        static void AddToXml(string pName, string pStreet,string pHouseNumber, string pFlatNumber, string pMobilePhone, string pFlatPhone, string path)
        {
            XElement person = new XElement("Person");
            XElement address = new XElement("Address");
            XElement houseNumber = new XElement("HouseNumber", pHouseNumber);
            XElement phones = new XElement("Phones");
            XElement street = new XElement("Street", pStreet);
            XElement flatNumber = new XElement("FlatNumber", pFlatNumber);
            XElement mobilePhone = new XElement("MobilePhone", pMobilePhone);
            XElement flatPhone = new XElement("FlatPhone", pFlatPhone);
            XAttribute name = new XAttribute("name", pName);

            person.Add(name, address, phones);
            address.Add(street, houseNumber, flatNumber);
            phones.Add(mobilePhone, flatPhone);

            person.Save(path);
        }

        /// <summary>
        /// Чтение из xml
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void ReadAndPrintFromXml(string path)
        {
            string xml = File.ReadAllText(path);

            string name =  XDocument.Parse(xml).Element("Person").Attribute("name").Value;
            XElement address =  XDocument.Parse(xml).Element("Person").Element("Address");
            string street = address.Element("Street").Value;
            string houseNumber = address.Element("HouseNumber").Value;
            string flatNumber = address.Element("FlatNumber").Value;
            XElement phones = XDocument.Parse(xml).Element("Person").Element("Phones");
            string mobilePhone = phones.Element("MobilePhone").Value;
            string flatPhone = phones.Element("FlatPhone").Value;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n{"ФИО: ",20}{name}");
            Console.WriteLine($"{"Улицу: ",20}{street}");
            Console.WriteLine($"{"Номер дома: ",20}{houseNumber}");            
            Console.WriteLine($"{"Номер Квартиры: ",20}{flatNumber}");
            Console.WriteLine($"{"Мобильный телефон: ",20}{mobilePhone}");
            Console.WriteLine($"{"Домашний телефон: ",20}{flatPhone}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Вывод данных на консоль
        /// </summary>
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n{"ФИО: ",20}{Fio}");
            Console.WriteLine($"{"Улицу: ",20}{Street}");
            Console.WriteLine($"{"Номер дома: ", 20}{House}");            
            Console.WriteLine($"{"Номер Квартиры: ",20}{Flat}");
            Console.WriteLine($"{"Мобильный телефон: ",20}{MobilePhoneNumber}");
            Console.WriteLine($"{"Домашний телефон: ",20}{PhoneNumber}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion
    }
}
