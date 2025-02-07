﻿using System;
using System.Net.Sockets;
using System.Text;

namespace Unknown_World_of_Mystery_server
{
    /// <summary>
    /// сервер получает команды и формирует ответ
    /// </summary>
    public class Server
    {
        public TcpClient client;

        public Server(TcpClient client)
        {
            this.client = client;
        }

        public void Process()
        {
            NetworkStream stream = null;
            ushort key;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[64]; // буфер для получаемых данных
                string response = ""; // ответ
                while (true)
                {
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message = builder.ToString();
                    // расшифровываем сообщение
                    key = ushort.Parse(FileManager.ReadingFile(FileManager.pathToKey));
                    message = EncryptionLibrary.EncryptionClass.EncryptDecrypt(message, key);
                    Console.WriteLine(message);
                    // отправляем сообщение
                    message = message.Substring(message.IndexOf(':') + 1).Trim();
                    string[] command = message.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                    // зашифровываем ответ
                    // меняем ключ
                    Random random = new Random();
                    FileManager.WritingFile(FileManager.pathToKey, random.Next(0, 39321).ToString());
                    key = ushort.Parse(FileManager.ReadingFile(FileManager.pathToKey));
                    response = FormResponse(command);
                    Console.WriteLine("Server: " + response);
                    data = Encoding.Unicode.GetBytes(EncryptionLibrary.EncryptionClass.EncryptDecrypt(response, key));
                    stream.Write(data, 0, data.Length);
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }

        /// <summary>
        /// формирование ответа сервера
        /// </summary>
        /// <param name="command">команда</param>
        /// <returns>ответ сервера</returns>
        public string FormResponse(string[] command)
        {
            Database database = new Database(
                new QueryGetUsernames(), 
                new QueryGetPassword(command), 
                new QueryCreateUser(command),
                new QueryGetCharacters(command),
                new QueryCreateCharacter(command),
                new QueryGetCharacterNames(command),
                new QueryUpdateCharacter(command));

            Broker broker = new Broker(
                new CommandLogIn(command, database),
                new CommandRegister(command, database),
                new CommandChooseCharacter(database),
                new CommandCreateCharacter(command, database),
                new CommandSave(database),
                new CommandShowListLeaders(command, database));

            database.FillInTheQueryDictionary();
            broker.FillInTheCommandDictionary();
            return broker.ExecuteCommand(command[0]);
        }
    }
}
