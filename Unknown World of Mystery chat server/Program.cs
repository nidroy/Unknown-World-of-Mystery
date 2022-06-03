using System;
using System.Threading;

namespace Unknown_World_of_Mystery_chat_server
{
    class Program
    {
        static ServerObject server; // сервер
        static Thread listenThread; // потока для ожидания подключений
        static void Main(string[] args)
        {
            try
            {
                server = new ServerObject(); // создание объекта
                listenThread = new Thread(new ThreadStart(server.Listen)); // создание отдельного потока
                listenThread.Start(); //запуск потока
            }
            catch (Exception ex) // в случае возникновения ошибки
            {
                server.Disconnect(); // выключаем сервер
                Console.WriteLine(ex.Message); // выводим текст ошибки на экран
            }
        }
    }
}