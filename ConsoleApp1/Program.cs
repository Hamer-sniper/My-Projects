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
            Console.WriteLine("Задание 1: Лист целых чисел");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            List<int> myList = new List<int>();
            int elementsCount = 100;

            AddNumbers(myList, elementsCount);
            Show(myList, elementsCount);

            int collectionLenght = DeleteNumbers(myList, elementsCount);
            Show(myList, collectionLenght);
          
            Console.ReadKey();
        }

        /// <summary>
        /// Вывести коллекцию на экран
        /// </summary>
        /// <param name="myList">Коллекция</param>
        /// <param name="count">Количество итераций</param>
        static void Show(List<int> myList, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{myList[i],2} ");
            }
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Заполнить коллекцию целыми числами от 0 до 100
        /// </summary>
        /// <param name="myList">Коллекция</param>
        /// <param name="count">Количество итераций</param>
        static void AddNumbers(List<int> myList, int count)
        {
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                myList.Add(rand.Next(0, 100));
            }
        }

        /// <summary>
        /// Удаление элементов из коллекции
        /// </summary>
        /// <param name="myList">Коллекция</param>
        /// <param name="count">Количество итераций</param>
        /// <returns>Количество элементов</returns>
        static int DeleteNumbers(List<int> myList, int count)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                if (myList[i] < 50 && myList[i] > 25)
                {
                    myList.RemoveAt(i);
                }
            }
            return myList.Count();
        }
    }
}
