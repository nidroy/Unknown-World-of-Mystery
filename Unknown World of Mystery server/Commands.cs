using System;
using System.Collections;

namespace Unknown_World_of_Mystery_server
{
    /// <summary>
    /// команда авторизации
    /// </summary>
    public class CommandLogIn : ICommand
    {
        string[] user;// имя пользователя и пароль
        Database database;// бд

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="user">данные пользователя</param>
        /// <param name="database">бд</param>
        public CommandLogIn(string[] user, Database database)
        {
            this.user = user;
            this.database = database;
        }

        /// <summary>
        /// выполнение команды
        /// </summary>
        /// <returns>строка об успешной регистрации пользователя</returns>
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

    /// <summary>
    /// команда регистрации
    /// </summary>
    public class CommandRegister : ICommand
    {
        Database database;// бд

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="database">бд</param>
        public CommandRegister(Database database)
        {
            this.database = database;
        }

        /// <summary>
        /// выполнение команды
        /// </summary>
        /// <returns>создание нового пользователя</returns>
        public string Execute()
        {
            return database.ExecuteQuery("CreateUser");
        }
    }
    
    /// <summary>
    /// команда выбора персонажа
    /// </summary>
    public class CommandChooseCharacter : ICommand
    {
        Database database;// бд

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="database">бд</param>
        public CommandChooseCharacter(Database database)
        {
            this.database = database;
        }

        /// <summary>
        /// выполнение команды
        /// </summary>
        /// <returns>персонажи</returns>
        public string Execute()
        {
            return database.ExecuteQuery("GetCharacters");
        }
    }

    /// <summary>
    /// команда создания персонажа
    /// </summary>
    public class CommandCreateCharacter : ICommand
    {
        string[] character;// имя персонажа
        Database database;// бд

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="character">элементы персонажа</param>
        /// <param name="database"></param>
        public CommandCreateCharacter(string[] character, Database database)
        {
            this.character = character;
            this.database = database;
        }

        /// <summary>
        /// выполнение команды
        /// </summary>
        /// <returns>если персонажа еще нет, он будет создан</returns>
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

}
