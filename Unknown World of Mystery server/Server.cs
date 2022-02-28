using System;
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
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[64]; // буфер для получаемых данных
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
                    Console.WriteLine(message);
                    // отправляем сообщение
                    message = message.Substring(message.IndexOf(':') + 1).Trim();
                    string[] command = message.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                    data = Encoding.Unicode.GetBytes(FormResponse(command));
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
                new QueryGetCharacterNames(command));

            Broker broker = new Broker(
                new CommandLogIn(command, database),
                new CommandRegister(database),
                new CommandChooseCharacter(database),
                new CommandCreateCharacter(command, database));

            database.FillInTheQueryDictionary();
            broker.FillInTheCommandDictionary();
            return broker.ExecuteCommand(command[0]);
        }
    }
}
