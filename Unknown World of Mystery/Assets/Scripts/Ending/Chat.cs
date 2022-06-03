using UnityEngine;
using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    static string userName;
    private const string host = "127.0.0.1"; // ip адре сервера 
    private const int port = 9999; // порт который прослушивает сервер
    static TcpClient client;
    static NetworkStream stream;

    public InputField inputMessage;
    public Text outputText;

    private void Start()
    {
        if (!GameManager.isLocalAccount)
        {
            Connection();
        }
    }

    private void Update()
    {
        if(outputText.text.Length >= 100)
        {
            outputText.text = "";
        }
    }

    private void Connection()
    {
        userName = GameManager.username;
        client = new TcpClient();
        try
        {
            client.Connect(host, port); //подключение клиента к серверу
            stream = client.GetStream(); // получаем потока данных

            byte[] data = Encoding.Unicode.GetBytes(userName); // переводим никнейм в байты
            stream.Write(data, 0, data.Length); // записываем байты в поток

            // запускаем новый поток для получения данных
            Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
            receiveThread.Start(); //старт потока
            outputText.text += String.Format("Welcome {0}\n", userName);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
    // отправка сообщений
    public void SendMessage()
    {
        if (GameManager.isLocalAccount)
        {
            outputText.text = "Being in a local account, sending messages is not possible.";
        }
        else
        {
            string message = inputMessage.text;
            outputText.text += String.Format("You: {0}\n", message);
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
    }
    // получение сообщений
    private void ReceiveMessage()
    {
        while (true)
        {
            try
            {
                byte[] data = new byte[64]; // буфер для получаемых данных
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable == false && bytes == 0);

                string message = builder.ToString();
                outputText.text += message + "\n";//вывод сообщения
            }
            catch
            {
                outputText.text += "Connection interrupted!\n"; //соединение было прервано
                Disconnect();
                return;
            }
        }
    }

    private void Disconnect()
    {
        if (stream != null)
            stream.Close();//отключение потока
        if (client != null)
            client.Close();//отключение клиента
    }
}
