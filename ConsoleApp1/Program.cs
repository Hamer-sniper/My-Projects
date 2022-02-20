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
            Console.ForegroundColor = ConsoleColor.White;

            int row = 0;
            int col = 0;
            int sum = 0;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nВведите число строк: ");
                bool res1 = int.TryParse(Console.ReadLine(), out row);


                Console.Write("Введите число столбцов: ");
                bool res2 = int.TryParse(Console.ReadLine(), out col);

                if (res1 && res2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Исходная матрица : matrix[{row}, {col}]");
                    Console.ForegroundColor = ConsoleColor.White;

                    int[,] matrix = new int[row, col];

                    Random r = new Random();

                    for (int i = 0; i < row; i++)
                    {
                        sum = 0;
                        for (int j = 0; j < col; j++)
                        {
                            matrix[i, j] = r.Next(10);
                            sum += matrix[i, j];
                            Console.Write($"{matrix[i, j]} ");
                        }
                        Console.WriteLine($" : {sum}");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Размеры матрицы заданы не верно! Повторите попытку!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
