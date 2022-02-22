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
            // Задание 1
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание №1");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nВведите какое-нибудь длинное предложение, содержащее пробелы:");
            Console.ForegroundColor = ConsoleColor.White;

            var userStringMas = SplitStringToMas(Console.ReadLine());

            WriteLineMas(userStringMas);

            Console.ReadKey();
        }

        /// <summary>
        /// Возвращает массив слов из введенной строки
        /// </summary>
        /// <param name="Строка">userString</param>
        /// <returns></returns>
        static string[] SplitStringToMas(string userString)
        {
            string[] mas = userString.Split(' ');
            return mas;
        }

        /// <summary>
        /// Выводит на экран массив
        /// </summary>
        /// <param name="Массив">mas</param>
        static void WriteLineMas(string[] mas)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nПолучившийся массив слов:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var word in mas)
            {
                Console.WriteLine(word);
            }
        }
    }
}
