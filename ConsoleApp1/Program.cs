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
            // Требуется создать справочник сотрудники. В файле хранится: 
            //ID
            //Дата и время добавления записи
            //Ф.И.О.
            //Возраст
            //Рост
            //Дата рождения
            //Место рождения            
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Справочник \"Сотрудники\"");

            string fileName = "db.txt";
            char key = 'д';

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nВведите одну из следущих команд:");
                Console.WriteLine("1 - Вывести данные на экран");
                Console.WriteLine("2 - Заполнить данные и добавить новую запись в конец файла");
                Console.Write("Введите команду: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        if (File.Exists(fileName))
                        {
                            ReadFileAndShow(fileName);
                        }
                        else
                        {                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Не найден файл \"db.txt\", сначала создайте хотябы одну запись!");                            
                        }
                        break;
                    case "2":
                        AddData(fileName);
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
        /// <summary>
        /// Добавить данные в файл "db.txt"
        /// </summary>
        static void AddData(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.Unicode))
            {
                char keyAddData = 'д';                
                do
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n{"Добавление новой заметки",53}");
                    Console.ForegroundColor = ConsoleColor.White;

                    Employes employes = new Employes();

                    employes.ID = Guid.NewGuid().ToString();
                    Console.WriteLine($"{"ID: ",29}{employes.ID}");
 
                    employes.DateAndTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    Console.WriteLine($"{"Дата и время заметки: ",29}{employes.DateAndTime}");

                    Console.Write($"{"ФИО: ",29}");                    
                    employes.Name = Console.ReadLine();

                    Console.Write($"{"Введите возраст: ",29}");                   
                    employes.Age = Console.ReadLine();

                    Console.Write($"{"Введите рост: ",29}");                    
                    employes.Hight = Console.ReadLine();

                    Console.Write($"{"Дата рождения: ",29}");                    
                    employes.DayOfBurth = Console.ReadLine();

                    Console.Write($"{"Место рождения: ",29}");                    
                    employes.PlaceOfBurn = Console.ReadLine();

                    sw.WriteLine($"{employes.ID}#{employes.DateAndTime}#{employes.Name}#{employes.Age}#{employes.Hight}#{employes.DayOfBurth}#{employes.PlaceOfBurn}#");
                    sw.Close();                    
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{"Заметка создана!",45}");                   
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nДобавить еще данные? н/д");
                    keyAddData = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(keyAddData) == 'д');
            }
        }
        /// <summary>
        /// Считать данные и вывести на экран
        /// </summary>
        static void ReadFileAndShow(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName, Encoding.Unicode))
            {
                string line;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{"ID",3}{"Дата и время",17}{"ФИО автора",40}{"Возраст",8}{"Рост",5}{"Дата рождения",14}{"Место рождения",20}");
                Console.ForegroundColor = ConsoleColor.White;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    Console.WriteLine($"{data[0],3}{data[1],17}{data[2],40}{data[3],8}{data[4],5}{data[5],14}{data[6],20}");
                }
            }
        }
    }
}
