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

    static string SendingMessage(string username, string message)
    {
        TcpClient client = null;
        try
        {
            client = new TcpClient(address, port);
            NetworkStream stream = client.GetStream();
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
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
        finally
        {
            client.Close();
        }
        return message;
    }
}
