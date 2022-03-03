using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsoleApp
{
    /// <summary>
    /// Структура по работе с данными
    /// </summary>
    struct Repository
    {
        #region Поля
        private Employes[] employes;        // Основной массив для хранения данных
        private string path;                // Путь к файлу с данными
        private int index;                  // Текущий элемент для добавления в Employes
        private string[] titles;            // Массив, храняий заголовки полей. используется в PrintDbToConsole
        #endregion

        #region Свойства
        /// <summary>
        /// Количество сотрудников в хранилище
        /// </summary>
        public int Count { get { return this.index; } }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Констрктор
        /// </summary>
        /// <param name="Path">Путь в файлу с данными</param>
        public Repository(string Path, string[] Header)
        {
            this.path = Path;                // Сохранение пути к файлу с данными
            this.index = 0;                  // Текущая позиция для добавления сотрудника в Employes
            this.titles = Header;            // Получение массива заголовков
            this.employes = new Employes[1]; // Инициализаия массива сотрудников.     |      изначально предпологаем, что данных нет

            if (!File.Exists(this.path))
            {
                File.Create(this.path).Close();
            }
            this.Load(); // Загрузка данных
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод загрузки данных
        /// </summary>
        private void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    Add(new Employes(args[0], args[1], args[2], args[3], args[4], args[5], args[6]));
                }
            }
        }

        /// <summary>
        /// Метод получения данных о сотруднике из консоли
        /// </summary>
        public void AddFromConsole()
        {
            char keyAddData = 'д';
            do
            {
                this.AskUser(int.MaxValue);
                this.Save(this.path);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{"Запись создана!",45}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nДобавить еще данные? н/д");

                keyAddData = Console.ReadKey(true).KeyChar;
            } while (char.ToLower(keyAddData) == 'д');
        }

        /// <summary>
        /// Метод опроса пользователя
        /// </summary>
        /// <param name="indexToChange">Индекс изменяемого сотрудника</param>
        private void AskUser(int indexToChange)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{"Добавление новой заметки",53}");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write($"{"ФИО: ",29}");
            string tName = Console.ReadLine();

            Console.Write($"{"Введите возраст: ",29}");
            string tAge = Console.ReadLine();

            Console.Write($"{"Введите рост: ",29}");
            string tHight = Console.ReadLine();

            Console.Write($"{"Дата рождения: ",29}");
            string tDayOfBurth = Console.ReadLine();

            Console.Write($"{"Место рождения: ",29}");
            string tPlaceOfBurn = Console.ReadLine();

            if (indexToChange == int.MaxValue)
                Add(new Employes(tName, tAge, tHight, tDayOfBurth, tPlaceOfBurn));
            else
                ChangeConcreteUser(new Employes(tName, tAge, tHight, tDayOfBurth, tPlaceOfBurn), indexToChange);
        }

        /// <summary>
        /// Метод изменения сотрудника в хранилище
        /// </summary>
        /// <param name="ConcreteWorker">Сотрудник</param>
        /// <param name="indexToChange">Индекс изменяемого сотрудника</param>
        private void ChangeConcreteUser(Employes ConcreteWorker, int indexToChange)
        {
            this.employes[indexToChange] = ConcreteWorker;
        }

        /// <summary>
        /// Метод добавления сотрудника в хранилище
        /// </summary>
        /// <param name="ConcreteWorker">Сотрудник</param>
        private void Add(Employes ConcreteWorker)
        {
            this.Resize(index >= this.employes.Length);
            this.employes[index] = ConcreteWorker;
            this.index++;
        }

        /// <summary>
        /// Метод сортировки записей по дате
        /// </summary>
        public void SortByDate()
        {
            DateTime userDate = DateTime.MaxValue;
            DateTime userDate2 = DateTime.MaxValue;
            int head = 0;                               // Указатель головного элемента
            int tail = index-1;                         // Указатель хвостового элемента

            Employes tEmployee = new Employes();

            bool flag = true;                          // Флаг, показывающий увеличивать позицию головного                                                       

            while (true)                               // Пока "голова" меньше "хвоста"
            {
                userDate = DateTime.MaxValue;
                userDate2 = DateTime.MaxValue;
                DateTime.TryParse(this.employes[head].DateAndTime, out userDate);
                DateTime.TryParse(this.employes[tail].DateAndTime, out userDate2);
                
                if (flag)
                {
                    if (userDate > userDate2)
                        flag = false;                 // Работаем с головным элементом
                    else 
                        head++;
                }
                else                
                {
                    tEmployee = this.employes[head];                    //
                    this.employes[head] = this.employes[tail];          // Меняем их местами
                    this.employes[tail] = tEmployee;                    //

                    head = 0;                                           
                    flag = true;
                }

                if (head == tail)                   // Достигнув конца, сдвигаем хвост назад и начинаем цикл сначала
                {
                    tail--;
                    head = 0;
                }

                if (tail == 0)                     // Дошли до головного элемента - завершаем
                    break;
            }

            // Вывод информации (без refresh)
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{this.titles[0],5}{this.titles[1],9}{this.titles[2],17}{this.titles[3],35}{this.titles[4],8}{this.titles[5],5}{this.titles[6],14}{this.titles[7],20}");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine($"{i + 1,5}{this.employes[i].Print()}");
            }            
        }

        /// <summary>
        /// Метод поиска записей за определенную дату
        /// </summary>
        public void FindDate()
        {
            DateTime startDate = DateTime.MaxValue;
            DateTime endDate = DateTime.MaxValue;
            DateTime userDate = DateTime.MaxValue;

            Console.Write("Введите начальную дату для поиска данных: ");
            DateTime.TryParse(Console.ReadLine(), out startDate);
            Console.Write("Введите конечную дату для поиска данных: ");
            DateTime.TryParse(Console.ReadLine(), out endDate);           

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{this.titles[0],5}{this.titles[1],9}{this.titles[2],17}{this.titles[3],35}{this.titles[4],8}{this.titles[5],5}{this.titles[6],14}{this.titles[7],20}");
            Console.ForegroundColor = ConsoleColor.White;

            if (startDate != DateTime.MaxValue && endDate != DateTime.MaxValue)
            {
                endDate = endDate.AddDays(1);
                endDate = endDate.AddSeconds(-1);

                for (int i = 0; i < index; i++)
                {
                    DateTime.TryParse(this.employes[i].DateAndTime.Substring(0, 10), out userDate);
                    if (userDate != DateTime.MaxValue && userDate <= endDate && userDate >= startDate)
                    {
                        Console.WriteLine($"{i + 1,5}{this.employes[i].Print()}");
                    }
                }
            }
        }

        /// <summary>
        /// Метод изменения записи сотрудника
        /// </summary>        
        public void Change()
        {
            int changeUser = int.MaxValue;

            Console.Write("Введите номер строки для изменения: ");
            int.TryParse(Console.ReadLine(), out changeUser);

            File.Delete(this.path);

            for (int i = 0; i < index; i++)
            {
                if (i + 1 == changeUser)
                    AskUser(i);

                AppendText(i);
            }

            if (changeUser != int.MaxValue)
                this.Refresh();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"Запись измененена!",45}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Метод удаления сотрудника из хранилища
        /// </summary>       
        public void Delete()
        {
            int deleteNumber = int.MaxValue;

            Console.Write("Введите номер строки для удаления: ");
            int.TryParse(Console.ReadLine(), out deleteNumber);

            File.Delete(this.path);

            for (int i = 0; i < index; i++)
            {
                if (i + 1 == deleteNumber)
                    continue;
                AppendText(i);
            }

            if (deleteNumber != int.MaxValue)
                this.Refresh();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"Запись удалена!",45}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Метод добавления записи в конец файла (Через цикл)
        /// </summary>
        /// <param name="i">Текущая итерация</param>
        private void AppendText(int i)
        {
            string temp = String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                                                this.employes[i].ID,
                                                this.employes[i].DateAndTime,
                                                this.employes[i].Name,
                                                this.employes[i].Age,
                                                this.employes[i].Hight,
                                                this.employes[i].DayOfBurth,
                                                this.employes[i].PlaceOfBurn);

            File.AppendAllText(this.path, $"{temp}\n", Encoding.Unicode);
        }

        /// <summary>
        /// Метод для обновления информации
        /// </summary>
        private void Refresh()
        {
            this.index = 0;
            this.Load();
        }

        /// <summary>
        /// Метод увеличения текущего хранилища
        /// </summary>
        /// <param name="Flag">Условие увеличения</param>
        private void Resize(bool Flag)
        {
            if (Flag)
                Array.Resize(ref this.employes, this.employes.Length * 2);
        }

        /// <summary>
        /// Метод сохранения данных
        /// </summary>
        /// <param name="Path">Путь к файлу сохранения</param>
        public void Save(string Path)
        {
            string temp = String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                                    this.employes[this.index - 1].ID,
                                    this.employes[this.index - 1].DateAndTime,
                                    this.employes[this.index - 1].Name,
                                    this.employes[this.index - 1].Age,
                                    this.employes[this.index - 1].Hight,
                                    this.employes[this.index - 1].DayOfBurth,
                                    this.employes[this.index - 1].PlaceOfBurn);
            File.AppendAllText(Path, $"{temp}\n", Encoding.Unicode);
        }

        /// <summary>
        /// Метод вывода данных в консоль
        /// </summary>
        public void PrintDbToConsole()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{this.titles[0],5}{this.titles[1],9}{this.titles[2],17}{this.titles[3],35}{this.titles[4],8}{this.titles[5],5}{this.titles[6],14}{this.titles[7],20}");
            Console.ForegroundColor = ConsoleColor.White;

            this.Refresh();

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine($"{i + 1,5}{this.employes[i].Print()}");
            }
        }
    }
    #endregion
}
