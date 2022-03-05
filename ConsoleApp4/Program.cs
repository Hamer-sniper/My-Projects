using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HelloWorldConsoleApp
{
    class Program
    {
        /// <summary>
        /// Сериализация типа Notebook
        /// </summary>
        /// <param name="notebook">Тип для сериализации</param>
        /// <param name="path">Путь к файлу</param>
        static void SerializeNotebook(Notebook notebook, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Notebook));

            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);

            serializer.Serialize(stream, notebook);

            stream.Close();
        }

        /// <summary>
        /// Десериализация типа Notebook
        /// </summary>        
        /// <param name="path">Путь к файлу</param>
        static Notebook DesrializeNotebook(string path)
        {
            Notebook tempNotebook = new Notebook();

            XmlSerializer serializer = new XmlSerializer(typeof(Notebook));

            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            tempNotebook = serializer.Deserialize(stream) as Notebook;

            stream.Close();

            return tempNotebook;
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание 4. Записная книжка");
            Console.ForegroundColor = ConsoleColor.White;

            Notebook notebook = new Notebook();
            string path = "Phone.xml";

            notebook.AddFromUser(path);

            notebook.ReadAndPrintFromXml(path);
            
            /*
            SerializeNotebook(notebook, "SrializedBD.xml");
            notebook.Print();
            DesrializeNotebook("SrializedBD.xml").Print();
            */

            Console.ReadKey();
        }
    }
}
