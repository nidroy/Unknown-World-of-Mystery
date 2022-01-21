using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionLibrary;

namespace Unknown_World_of_Mystery_server
{
    public class Broker
    {
        public Dictionary<string, ICommand> commandDictionary = new Dictionary<string, ICommand>();
        List<ICommand> command = new List<ICommand>();

        public Broker(ICommand LogIn, ICommand Register, ICommand ChooseCharacter, ICommand CreateCharacter, ICommand Apply)
        {
            command.Add(LogIn);
            command.Add(Register);
            command.Add(ChooseCharacter);
            command.Add(CreateCharacter);
            command.Add(Apply);
        }

        public void FillInTheCommandDictionary()
        {
            commandDictionary.Clear();
            commandDictionary.Add("LogIn", command[0]);
            commandDictionary.Add("Register", command[1]);
            commandDictionary.Add("ChooseCharacter", command[2]);
            commandDictionary.Add("CreateCharacter", command[3]);
            commandDictionary.Add("Apply", command[4]);
        }

        public string ExecuteCommand(string command)
        {
            return commandDictionary[command].Execute();
        }
    }
}
