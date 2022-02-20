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



            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nВведите длину последовательности: ");

                // Проверяем коорекность ввода целого числа
                if (int.TryParse(Console.ReadLine(), out int integer))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Отлично! Теперь требуется поочередно ввести целые числа");
                    Console.ForegroundColor = ConsoleColor.White;

                    int[] mas = new int[integer];

                    for (int i = 0; i < integer; i++)
                    {
                        while (true)
                        {
                            Console.Write($"Введите число №{i + 1}: ");

                            try
                            {
                                mas[i] = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Вы ввели не целое число! Повторите попытку!");
                                Console.ForegroundColor = ConsoleColor.White;
                                i--;
                                break;
                            }
                            break;
                        }
                    }
                    int minElement = int.MaxValue;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"Получившийся массив: ");

                    foreach (int element in mas)
                    {
                        if (element < minElement)
                            minElement = element;
                        Console.Write($"{element} ");
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nМинимальный элемент: {minElement}");


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
