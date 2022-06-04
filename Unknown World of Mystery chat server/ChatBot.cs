using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Unknown_World_of_Mystery_chat_server
{
    public class ChatBot
    {
        private static string pathToDatabase = Environment.CurrentDirectory + "\\Database\\Unknown World of Mystery database.mdf"; // путь к бд 
        private static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + pathToDatabase + ";Integrated Security=True;Connect Timeout=30";

        public string FormResponse(string command)
        {

            return "";
        }
    }
}
