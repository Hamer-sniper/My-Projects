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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Задание №1");
            Console.ForegroundColor = ConsoleColor.White;

            string fullName = "Ахвердов Андрей Александрович", email = "wm-andrew@mail.ru";
            int age = 27;
            double programmingBal = 5, mathBal = 5, physicsBal = 4;
            
            Console.WriteLine("ФИО: {0}\nВозраст: {1}\nEmail: {2}\nБаллы по программированию: {3}\nБаллы по математике: {4}\nБаллы по физике: {5}",
                fullName,
                age,
                email,
                programmingBal,
                mathBal,
                physicsBal);

            Console.ReadKey();

            // Задание 2
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗадание №2");
            Console.ForegroundColor = ConsoleColor.White;

            double sumBalls = 0, averageBalls = 0;

            sumBalls = programmingBal + mathBal + physicsBal;
            averageBalls = sumBalls / 3;

            Console.WriteLine($"Сумма баллов: {sumBalls}");
            Console.WriteLine("Среднее арифметическое баллов: {0:0.00}", averageBalls);

            Console.ReadKey();

        }
    }
}
