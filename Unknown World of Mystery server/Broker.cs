using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionLibrary;

namespace Unknown_World_of_Mystery_server
{
    public class Broker : IBroker
    {
        public string FormResponse(string message)
        {
            return message;
        }
    }
}
