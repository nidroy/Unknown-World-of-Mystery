using System.Collections.Generic;

namespace Unknown_World_of_Mystery_server
{
    // класс для связи программы и сервера
    public class Broker
    {
        /// <summary>
        /// словарь команд
        /// </summary>
        public Dictionary<string, ICommand> commandDictionary = new Dictionary<string, ICommand>();
        List<ICommand> command = new List<ICommand>(); // команды

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="LogIn">команда авторизации</param>
        /// <param name="Register">команда регистрации</param>
        /// <param name="ChooseCharacter">комада выбора персонажа</param>
        /// <param name="CreateCharacter">команда создания персонажа</param>
        public Broker(ICommand LogIn, ICommand Register, ICommand ChooseCharacter, ICommand CreateCharacter)
        {
            command.Add(LogIn);
            command.Add(Register);
            command.Add(ChooseCharacter);
            command.Add(CreateCharacter);
        }

        /// <summary>
        /// заполнение словаря
        /// </summary>
        public void FillInTheCommandDictionary()
        {
            commandDictionary.Clear();
            commandDictionary.Add("LogIn", command[0]);
            commandDictionary.Add("Register", command[1]);
            commandDictionary.Add("ChooseCharacter", command[2]);
            commandDictionary.Add("CreateCharacter", command[3]);
        }

        /// <summary>
        /// выполнение команды
        /// </summary>
        /// <param name="command">команда</param>
        /// <returns>ответ сервера</returns>
        public string ExecuteCommand(string command)
        {
            return commandDictionary[command].Execute();
        }
    }
}
