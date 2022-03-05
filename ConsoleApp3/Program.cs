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
            Console.WriteLine("Задание 3. Проверка повторов");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВводите поочередно целые числа");
            Console.WriteLine("Чтобы закончить добавление чисел, оставьте строку вводу пустой");
            Console.ForegroundColor = ConsoleColor.White;

            HashSet<int> set = new HashSet<int>();

            while (true)
            {
                Console.Write("Введите число для добавления в множество: ");
                string userInput = Console.ReadLine();
                if (userInput == "" || userInput == null)
                    break;

                if (Int32.TryParse(userInput, out int userInputInt))
                {
                    if (!set.Add(userInputInt))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Это число уже вводилось ранее.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели не число! Повторите попытку");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Получившееся множество целых чисел:");
            foreach (int item in set)
                Console.WriteLine($"{item}");
            Console.ReadKey();
        }
    }
}
