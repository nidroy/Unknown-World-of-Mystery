using System;
using System.Net.Sockets;
using System.Text;

public class Client
{
    const int port = 8888;
    const string address = "127.0.0.1";

    /// <summary>
    /// отправка сообщения на сервер
    /// </summary>
    /// <param name="clientId">номер пользователя</param>
    /// <param name="message">сообщение</param>
    /// <returns>ответ сервера</returns>

    public static string SendingMessage(string clientId, string message)
    {
        TcpClient tcpClient = null;
        ushort key;
        try
        {
            tcpClient = new TcpClient(address, port);
            NetworkStream stream = tcpClient.GetStream();
            while (true)
            {
                // ввод сообщения
                message = String.Format("{0}: {1}", clientId, message);
                // преобразуем сообщение в массив байтов
                // меняем ключ
                Random random = new Random();
                FileManager.WritingFile(FileManager.pathToKey, random.Next(0, 39321).ToString());
                key = ushort.Parse(FileManager.ReadingFile(FileManager.pathToKey));
                byte[] data = Encoding.Unicode.GetBytes(EncryptionLibrary.EncryptionClass.EncryptDecrypt(message, key));
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
                // расшифровываем ответ
                key = ushort.Parse(FileManager.ReadingFile(FileManager.pathToKey));
                message = EncryptionLibrary.EncryptionClass.EncryptDecrypt(message, key);
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
