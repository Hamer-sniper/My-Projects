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
            Console.WriteLine("Справочник \"Сотрудники\"");

            string fileName = @"db.txt";
            string[] header = new string[] { "Номер", "ID", "Дата и время", "ФИО", "Возраст", "Рост", "Дата рождения", "Место рождения" };
            Repository rep = new Repository(fileName, header);

            char key = 'д';

            do
            {                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nВведите одну из следущих команд:");
                Console.WriteLine("1 - Вывести данные на экран");
                Console.WriteLine("2 - Заполнить данные и добавить новую запись в конец файла");
                Console.WriteLine("3 - Удалить данные по номеру строки");
                Console.WriteLine("4 - Изменить данные по номеру строки");
                Console.WriteLine("5 - Найти записи за определенный период");
                Console.WriteLine("6 - Отсортировать записи по дате добавления");
                Console.WriteLine("0 - Выход");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите команду: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        rep.PrintDbToConsole();
                        break;
                    case "2":
                        rep.AddFromConsole();
                        break;
                    case "3":
                        rep.Delete();
                        break;
                    case "4":
                        rep.Change();
                        break;
                    case "5":
                        rep.FindDate();
                        break;
                    case "6":
                        rep.SortByDate();
                        break;
                    case "0":
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Не верно введена команда! ");
                        break;
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nПродолжить работу со справочником? н/д");
                key = Console.ReadKey(true).KeyChar;
                Console.WriteLine();

            } while (char.ToLower(key) == 'д');

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nСпасибо за использование справочника!");
            Thread.Sleep(3000);
        }
    }
}
