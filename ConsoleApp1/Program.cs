using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using System.IO;
using Telegram.Bot.Args;
using System.Net.Http;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace HelloWorldConsoleApp
{
    class Program
    {
        #region Телеграм бот v1
        /*
        /// <summary>
        /// Телеграм бот v1
        /// </summary>
        static void BackgoundBot()
        {
            string token = File.ReadAllText(@"D:\Programming\DzSkillbox\ConsoleApp1\Info\t_bot.txt", Encoding.UTF8);
            WebClient webClient = new WebClient() { Encoding = Encoding.UTF8 };

            int update_id = 0;
            string startUrl = $@"https://api.telegram.org/bot{token}/";

            while (true)
            {
                string url = $"{startUrl}getUpdates?offset={update_id}";
                var r = webClient.DownloadString(url);

                //Console.WriteLine(r);
                //Console.ReadLine();

                var msgs = JObject.Parse(r)["result"].ToArray();

                foreach (dynamic msg in msgs)
                {
                    update_id = Convert.ToInt32(msg.update_id) + 1;

                    string userMessage = msg.message.text;
                    string userId = msg.message.from.id;
                    string useFirstrName = msg.message.from.first_name;

                    string text = $"{useFirstrName} {userId} {userMessage}";

                    Console.WriteLine(text);

                    if (userMessage == "hi")
                    {
                        string responseText = $"Здравствуйте, {useFirstrName}";
                        url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";
                        webClient.DownloadString(url);
                    }
                }
                Thread.Sleep(100);
            }
        }
        */
        #endregion

        static TelegramBotClient bot;
        static void Main(string[] args)
        {
            string token = System.IO.File.ReadAllText(@"D:\Programming\DzSkillbox\ConsoleApp1\Info\t_bot.txt", Encoding.UTF8);

            #region exc

            ////// https://hidemyna.me/ru/proxy-list/?maxtime=250#list

            //// Содержит параметры HTTP-прокси для System.Net.WebRequest класса.
            //var proxy = new WebProxy()
            //{
            //    Address = new Uri($"http://77.87.240.74:3128"),
            //    UseDefaultCredentials = false,
            //    //Credentials = new NetworkCredential(userName: "login", password: "password")
            //};

            //// Создает экземпляр класса System.Net.Http.HttpClientHandler.
            //var httpClientHandler = new HttpClientHandler() { Proxy = proxy };

            //// Предоставляет базовый класс для отправки HTTP-запросов и получения HTTP-ответов 
            //// от ресурса с заданным URI.
            //HttpClient hc = new HttpClient(httpClientHandler);

            //bot = new TelegramBotClient(token, hc);

            #endregion            

            bot = new TelegramBotClient(token);

            bot.StartReceiving();
            bot.OnMessage += MessageListener;

            Console.ReadKey();
        }

        private static async void MessageListener(object sender, MessageEventArgs e)
        {
            string text = $"{DateTime.Now.ToLongTimeString()}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";
            Random random = new Random();

            Console.WriteLine($"{text} TypeMessage: {e.Message.Type.ToString()}");

            switch (e.Message.Type)
            {
                case Telegram.Bot.Types.Enums.MessageType.Document: DownLoad(e.Message.Document.FileId, e.Message.Document.FileName); break;
                case Telegram.Bot.Types.Enums.MessageType.Audio: DownLoad(e.Message.Audio.FileId, e.Message.Audio.FileName); break;
                case Telegram.Bot.Types.Enums.MessageType.Photo: DownLoad(e.Message.Photo[3].FileId, $"{DateTimeToName()}_{random.Next(0, 100)}.jpg"); break;
                case Telegram.Bot.Types.Enums.MessageType.Video: DownLoad(e.Message.Video.FileId, e.Message.Video.FileName); break;
                case Telegram.Bot.Types.Enums.MessageType.Voice: DownLoad(e.Message.Voice.FileId, $"{DateTimeToName()}_{random.Next(0, 100)}.ogg"); break;
                default: if (e.Message.Text == null) return; break;
            }
            SendedMessages(e);
        }

        static async void SendedMessages(MessageEventArgs e)
        {
            var messageText = e.Message.Text;
            string text = $"Загрузите свой файл, просмотрите список файлов и скачайте любой из них!\nТакже через <Название> можно найти информацию о чем угодно из Wikipedia)";

            if ((messageText == "d" || messageText == "D") && System.IO.File.Exists(e.Message.ReplyToMessage.Text))
            {
                DownloadChosenFile(e, e.Message.ReplyToMessage.Text);
                return;
            }
            switch (messageText)
            {
                case "Список файлов": ListMyDownloadedFiles(e); break;
                case "/start": 
                    await bot.SendTextMessageAsync(e.Message.Chat.Id, $"Приветствие от бота!");                    
                    await bot.SendTextMessageAsync(e.Message.Chat.Id, text, replyMarkup: GetButtons());
                    break;                
                default: await bot.SendTextMessageAsync(e.Message.Chat.Id, WikiInfo(e), replyMarkup: GetButtons()); break;
            }
        }

        static string WikiInfo(MessageEventArgs e)
        {
            string myWebAdress = "https://ru.wikipedia.org/wiki/";
            myWebAdress += e.Message.Text;
            return myWebAdress;
        }

        static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup()
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Список файлов"} }                    
                }
            };
        }

        static void ListMyDownloadedFiles(MessageEventArgs e)
        {
            var myFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "_*");            
            foreach (var file in myFiles)
                bot.SendTextMessageAsync(e.Message.Chat.Id, Path.GetFileName(file));
            bot.SendTextMessageAsync(e.Message.Chat.Id, "Чтобы скачать какой-либо файл, ответьте на сообщение с ним буквой \"d\"");
        }

        static async void DownloadChosenFile(MessageEventArgs e, string myFileDownload)
        {
            using (FileStream stream = System.IO.File.OpenRead(myFileDownload))
            {
                InputOnlineFile inputOnlineFile = new InputOnlineFile(stream, myFileDownload);
                await bot.SendDocumentAsync(e.Message.Chat.Id, inputOnlineFile);
            }
        }

        static async void DownLoad(string fileId, string path)
        {
            var file = await bot.GetFileAsync(fileId);
            FileStream fs = new FileStream("_" + path, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fs);
            fs.Close();

            fs.Dispose();
        }

        private static string DateTimeToName()
        {
            string str = DateTime.Now.ToString();
            str = str.Replace(" ", string.Empty);
            str = str.Replace(":", string.Empty);
            str = str.Replace(".", string.Empty);
            return str;
        }
    }
}