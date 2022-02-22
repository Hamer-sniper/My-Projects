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
            // Задание 2
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание №2");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nВведите какое-нибудь длинное предложение, содержащее пробелы:");
            Console.ForegroundColor = ConsoleColor.White;

            ReversWords(Console.ReadLine());

        }

        /// <summary>
        /// Выводит перевернутый массив слов из введенной строки
        /// </summary>
        /// <param name="Строка">userString</param>
        /// <returns></returns>
        static void ReversWords(string inputPhrase)
        {
            string[] splitedMas = SplitStringToMas(inputPhrase);
            string resultString = "";

            Array.Reverse(splitedMas);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Получившийся перевернутый массив слов:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var word in splitedMas)
            {
                resultString += word + " ";
            }
            Console.Write(resultString.Trim());
            Console.ReadKey();
        }

        /// <summary>
        /// Разделяет слова
        /// </summary>
        /// <param name="Массив">mas</param>
        static string[] SplitStringToMas(string userString)
        {
            string[] mas = userString.Split(' ');
            return mas;
        }
    }
}
