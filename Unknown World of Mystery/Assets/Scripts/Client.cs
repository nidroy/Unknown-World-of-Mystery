using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Client
{
    const int port = 8888;
    const string address = "127.0.0.1";

    /// <summary>
    /// отправка сообщения на сервер
    /// </summary>
    /// <param name="username">имя пользователя</param>
    /// <param name="message">сообщение</param>
    /// <returns>ответ сервера</returns>

    public static string SendingMessage(string username, string message)
    {
        TcpClient tcpClient = null;
        try
        {
            tcpClient = new TcpClient(address, port);
            NetworkStream stream = tcpClient.GetStream();
            while (true)
            {
                // ввод сообщения
                message = String.Format("{0}: {1}", username, message);
                // преобразуем сообщение в массив байтов
                byte[] data = Encoding.Unicode.GetBytes(message);
                // отправка сообщения
                stream.Write(data, 0, data.Length);
                // получаем ответ
                data = new byte[64]; // буфер для получаемых данных
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);
                message = builder.ToString();
                return message;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            tcpClient.Close();
        }
        return message;
    }
}
