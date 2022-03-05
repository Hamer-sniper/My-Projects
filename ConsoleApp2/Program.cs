using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание 2. Телефонная книга");

            bool exit = false;
            Dictionary<int, string> telephone = new Dictionary<int, string>();
            
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nВведите одну из следущих команд:");
                Console.WriteLine("1 - Добавить данные ");
                Console.WriteLine("2 - Показать данные ");
                Console.WriteLine("3 - Найти по номеру телефона");
                Console.WriteLine("4 - Выход");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nВведите команду: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddTelephoneNumber(telephone);
                        break;
                    case "2":
                        Show(telephone);
                        break;
                    case "3":
                        Find(telephone);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Не верно введена команда! ");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            } while (!exit);
        }

        /// <summary>
        /// Вывести данные на экран
        /// </summary>
        /// <param name="telephone">Словарь</param>
        static void Show(Dictionary<int, string> telephone)
        {
            if (telephone.Count == 0)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Элементов не найдено!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            foreach (var contact in telephone)
            {
                Console.WriteLine($"Телефон: {contact.Key}  ФИО: {contact.Value}");
            }
        }

        /// <summary>
        /// Добавить значение в словарь
        /// </summary>
        /// <param name="telephone">Словарь</param>
        static void AddTelephoneNumber(Dictionary<int, string> telephone)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Для выхода из режима добавления, оставьте строку ввода номера телефона пустой");
            Console.ForegroundColor = ConsoleColor.White;
            int key = -1;
            do
            {
                key = IntTelephoneNumberCheck();
                if (telephone.ContainsKey(key))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Запись уже содержтся в справочнике!");
                    Console.ForegroundColor = ConsoleColor.White;                    
                }
                else if (key != -1)
                {                
                    Console.Write("Введите  ФИО владельца: ");

                    telephone.Add(key, Console.ReadLine());

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Запись добавлена!");
                    Console.ForegroundColor = ConsoleColor.White;             
                }                
            } while (key != -1);
        }

        /// <summary>
        /// Найти по номеру телефона
        /// </summary>
        /// <param name="telephone">Словарь</param>
        static void Find(Dictionary<int, string> telephone)
        {
            int number = IntTelephoneNumberCheck();
            if (telephone.TryGetValue(number, out string value))
            {
                Console.WriteLine("По номеру телефона: \"{0}\" найдено значение: {1}.", number, value);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("По номеру телефона совпадений не найдено");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Проверка номера телефона на целое число
        /// </summary>        
        static int IntTelephoneNumberCheck()
        {
            int key = -1;
            while (key < 1)
            {                
                Console.Write("\nВведите номер телефона: ");
                string userString = Console.ReadLine();
                if (userString == "" || userString == null)
                    return -1;
                if (!Int32.TryParse(userString, out key) || key == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Номер телефона должен состоять только из цифр, и не должен быть равен 0!");
                    Console.ForegroundColor = ConsoleColor.White;
                }                
            }
            return key;
        }
    }
}
