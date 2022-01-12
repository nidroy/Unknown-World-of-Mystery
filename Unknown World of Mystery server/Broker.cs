﻿using System;
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

        public Broker(ICommand LogIn, ICommand Register)
        {
            command.Add(LogIn);
            command.Add(Register);
        }

        public void FillInTheCommandDictionary()
        {
            commandDictionary.Clear();
            commandDictionary.Add("LogIn", command[0]);
            commandDictionary.Add("Register", command[0]);
        }

        public string ExecuteCommand(string command)
        {
            return commandDictionary[command].Execute();
        }
    }
}
