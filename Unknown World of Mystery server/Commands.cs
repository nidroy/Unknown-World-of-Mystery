using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Unknown_World_of_Mystery_server
{
    public class LogIn : ICommand
    {
        string[] user;
        Database database;

        public LogIn(string[] user, Database database)
        {
            this.user = user;
            this.database = database;
        }

        public string Execute()
        {
            string[] usernames = database.ExecuteQuery("GetUsernames").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            IEnumerator username = usernames.GetEnumerator();
            while(username.MoveNext())
            {
                if(username.Current.ToString() == user[1] && database.ExecuteQuery("GetPassword") == user[2])
                {
                    return "user found";
                }
            }
            return "user not found";
        }
    }

    public class Register : ICommand
    {
        Database database;

        public Register(Database database)
        {
            this.database = database;
        }

        public string Execute()
        {
            return database.ExecuteQuery("CreateUser");
        }
    }
}
