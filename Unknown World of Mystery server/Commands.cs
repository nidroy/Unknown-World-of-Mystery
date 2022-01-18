using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Unknown_World_of_Mystery_server
{
    public class CommandLogIn : ICommand
    {
        string[] user;
        Database database;

        public CommandLogIn(string[] user, Database database)
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

    public class CommandRegister : ICommand
    {
        Database database;

        public CommandRegister(Database database)
        {
            this.database = database;
        }

        public string Execute()
        {
            return database.ExecuteQuery("CreateUser") + "\n" + database.ExecuteQuery("CreateSettings");
        }
    }
    
    public class CommandChooseCharacter : ICommand
    {
        Database database;

        public CommandChooseCharacter(Database database)
        {
            this.database = database;
        }

        public string Execute()
        {
            return database.ExecuteQuery("GetCharacters");
        }
    }

    public class CommandCreateCharacter : ICommand
    {
        Database database;

        public CommandCreateCharacter(Database database)
        {
            this.database = database;
        }

        public string Execute()
        {
            return database.ExecuteQuery("CreateCharacter");
        }
    }

    public class CommandGetSettings : ICommand
    {
        Database database;

        public CommandGetSettings(Database database)
        {
            this.database = database;
        }

        public string Execute()
        {
            return database.ExecuteQuery("GetSettings");
        }
    }

    public class CommandApply : ICommand
    {
        Database database;

        public CommandApply(Database database)
        {
            this.database = database;
        }

        public string Execute()
        {
            return database.ExecuteQuery("UpdateSettings");
        }
    }
}
