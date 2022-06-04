using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace Unknown_World_of_Mystery_chat_server
{
    public class ServerObject
    {
        static TcpListener tcpListener; // сервер для прослушивания новых подключений
        List<ClientObject> clients = new List<ClientObject>(); // все созданные подключения

        // добавление подключенного клиента в список
        protected internal void AddConnection(ClientObject clientObject)
        {
            clients.Add(clientObject);
        }

        // удаление подключенного клиента из списка
        protected internal void RemoveConnection(string id)
        {
            // получаем по id закрытое подключение
            ClientObject client = clients.FirstOrDefault(c => c.Id == id);
            // и удаляем его из списка подключений
            if (client != null)
                clients.Remove(client);
        }

        // ожидаем новых подключений
        protected internal void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 9999); // создание сервера для прослушивание порта
                tcpListener.Start(); // запуск сервера
                Console.WriteLine("Сервер чата запущен. Ожидание подключений..."); // сервер успешно запущен

                // в бесконечном цикле ждем новых подключений
                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient(); // ждем пока не появится клиент с запросом на подключение

                    ClientObject clientObject = new ClientObject(tcpClient, this); // создание объекта класса ClientObject
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process)); // создание отдельного потока для подключенного клиента
                    clientThread.Start(); // запуск потока
                }
            }
            catch (Exception ex) // в случае ошибки
            {
                Console.WriteLine(ex.Message); // выводим ошибку на экран
                Disconnect(); // выключаем сервер
            }
        }

        // отправляем сообщение всем клиентам кроме того кто отправил сообщение
        protected internal void BroadcastMessageEveryone(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message); // перевод сообщение в байты
            for (int i = 0; i < clients.Count; i++) // отправляем сообщение всем клиентам
            {
                if (clients[i].Id != id) // если id клиента не равно id отправляющего
                {
                    clients[i].Stream.Write(data, 0, data.Length); //передача данных
                }
            }
        }

        // отправка сообщение клиенту который отправил сообщение
        protected internal void BroadcastMessageOnlyone(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message); // перевод сообщение в байты
            for (int i = 0; i < clients.Count; i++) // отправляем сообщение всем клиентам
            {
                if (clients[i].Id == id) // если id клиента не равно id отправляющего
                {
                    clients[i].Stream.Write(data, 0, data.Length); //передача данных
                }
            }
        }

        // останавливаем сервер и закрываем программу
        protected internal void Disconnect()
        {
            tcpListener.Stop(); //остановка сервера

            for (int i = 0; i < clients.Count; i++) // разрываем подключение со всеми клиентами
            {
                clients[i].Close(); //отключение клиента
            }
            Environment.Exit(0); //завершение процесса
        }
    }
}
