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
            // Задание 3
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание №3");            

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nВведите целое число: ");

                // Проверяем коорекность ввода целого числа
                if (int.TryParse(Console.ReadLine(), out int integer))
                {
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели не целое число! Повторите попытку!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }
    }
}
