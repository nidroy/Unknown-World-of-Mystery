using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Unknown_World_of_Mystery_server
{
    /// <summary>
    /// создание патоков для клиентов
    /// </summary>
    class Program
    {
        const int port = 8888;
        const string address = "127.0.0.1";
        static TcpListener listener;

        static void Main(string[] args)
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse(address), port);
                listener.Start();
                Console.WriteLine("Сервер игры запущен. Ожидание подключений...");
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Server server = new Server(client);
                    // создаем новый поток для обслуживания нового клиента
                    Thread clientThread = new Thread(new ThreadStart(server.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }
    }
}
