using System;
using System.Net.Sockets;
using System.Text;

namespace Unknown_World_of_Mystery_chat_server
{
    public class ClientObject
    {
        protected internal string Id { get; private set; } // id клиента
        protected internal NetworkStream Stream { get; private set; } // поток данных
        string userName; // имя клиента 
        TcpClient client; // объект TCP клиента
        ServerObject server; // объект сервера

        // конструктор
        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
        }

        // получение сообщений и рассылка их другим клиентам
        public void Process()
        {
            try
            {
                Stream = client.GetStream(); // получение потока данных
                // получаем имя пользователя
                string message = GetMessage(); // плучаем имя клиента
                userName = message; // записываем имя клиента

                message = String.Format("{0} connected to the chat", userName);
                // посылаем сообщение о входе в чат всем подключенным пользователям
                server.BroadcastMessage(message, this.Id);
                Console.WriteLine(message);
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    try
                    {
                        message = GetMessage(); // получаем сообщение
                        message = String.Format("{0}: {1}", userName, message); // построение сообщения
                        Console.WriteLine(message); // вывод на экран сервера
                        server.BroadcastMessage(message, this.Id); // передача сообщения другим клиентам
                    }
                    catch
                    {
                        message = String.Format("{0} disconnected from the chat", userName);
                        Console.WriteLine(message);
                        server.BroadcastMessage(message, this.Id);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(this.Id);
                Close();
            }
        }

        // чтение входящего сообщения и преобразование в строку
        private string GetMessage()
        {
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length); // читаем байты из потока данных
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes)); // строим из байт текст
            }
            while (Stream.DataAvailable);

            return builder.ToString(); // выводим сообщение
        }

        // закрытие подключения
        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }
}
