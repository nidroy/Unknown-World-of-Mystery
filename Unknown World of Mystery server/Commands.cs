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
                    return String.Format("user found_{0}", database.ExecuteQuery("GetSettings"));
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
        string[] character;
        Database database;

        public CommandCreateCharacter(string[] character, Database database)
        {
            this.character = character;
            this.database = database;
        }

        public string Execute()
        {
            string[] characterNames = database.ExecuteQuery("GetCharacterNames").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            IEnumerator characterName = characterNames.GetEnumerator();
            while (characterName.MoveNext())
            {
                if (characterName.Current.ToString() == character[2])
                {
                    return "The character exists";
                }
            }
            return database.ExecuteQuery("CreateCharacter");
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
