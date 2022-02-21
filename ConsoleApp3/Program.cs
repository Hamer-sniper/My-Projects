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
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nИгра \"угадай-ка\"");
            Console.WriteLine("Кога вам надоест играть - напишите \"exit\"");

            Random random = new Random();            
            int userValue = 0, count = 0;
            string userString = "";

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nВведите целое число, до которго угадываем: ");                

                count = 0;
                userValue = -1;
                // Проверяем коорекность ввода целого числа
                if (int.TryParse(Console.ReadLine(), out int integer))
                {                
                    int randomValue = random.Next(integer);
                    Console.ForegroundColor = ConsoleColor.White;

                    while (randomValue != userValue)
                    {                        
                        try
                        {
                            Console.Write("\nВведите число: ");
                            userString = Console.ReadLine();
                            if (userString == "exit")
                                break;
                            userValue = Convert.ToInt32(userString);
                            count++;
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы ввели не целое число! Повторите попытку!");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }
                        if (userValue < randomValue)
                            Console.WriteLine("Введенное число меньше загаданного");
                        else if (userValue > randomValue)
                            Console.WriteLine("Введенное число больше загаданного");
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Загаданное число: {randomValue}, число попыток: {count}");
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
