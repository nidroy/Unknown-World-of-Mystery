using System;
using System.Collections;
using System.Collections.Generic;

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
        string[] user;// имя пользователя
        Database database;// бд        

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="user">элементы пользователя</param>
        /// <param name="database">бд</param>
        public CommandRegister(string[] user, Database database)
        {
            this.user = user;
            this.database = database;
        }

        /// <summary>
        /// выполнение команды
        /// </summary>
        /// <returns>создание нового пользователя</returns>
        public string Execute()
        {
            string[] userNames = database.ExecuteQuery("GetUsernames").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            IEnumerator userName = userNames.GetEnumerator();
            while (userName.MoveNext())
            {
                if (userName.Current.ToString() == user[1])
                {
                    return "The user exists";
                }
            }
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
        /// <param name="database">бд</param>
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

    /// <summary>
    /// команда сохранения
    /// </summary>
    public class CommandSave : ICommand
    {
        Database database;// бд

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="database">бд</param>
        public CommandSave(Database database)
        {
            this.database = database;
        }

        /// <summary>
        /// выполнение команды
        /// </summary>
        /// <returns>персонажи</returns>
        public string Execute()
        {
            return database.ExecuteQuery("UpdateCharacter");
        }
    }

    /// <summary>
    /// команда показа списка лидеров
    /// </summary>
    public class CommandShowListLeaders : ICommand
    {
        string[] listLength;// длинна списка
        Database database;// бд        

        /// <summary>
        /// конструктор
        /// </summary>
        /// /// <param name="listLength">длинна списка</param>
        /// <param name="database">бд</param>
        public CommandShowListLeaders(string[] listLength, Database database)
        {
            this.listLength = listLength;
            this.database = database;
        }

        /// <summary>
        /// выполнение команды
        /// </summary>
        /// <returns>создание нового пользователя</returns>
        public string Execute()
        {
            string result = "";
            string[] name = { "" , "" };
            List<string> list = new List<string>();
            list.Clear();
            string[] userNames = database.ExecuteQuery("GetUsernames").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            IEnumerator userName = userNames.GetEnumerator();
            while (userName.MoveNext())
            {
                name[1] = userName.Current.ToString();
                IQuery getCharacters = new QueryGetCharacters(name);
                string[] characters = getCharacters.Execute(Database.connectionString).Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                IEnumerator character = characters.GetEnumerator();
                while (character.MoveNext())
                {
                    string[] attributes = character.Current.ToString().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    list.Add(userName.Current.ToString() + "-" + attributes[0] + "-" + attributes[2]);
                }
            }
            IEnumerator enumerator = Sort(list, int.Parse(listLength[1])).GetEnumerator();
            while (enumerator.MoveNext())
            {
                result += enumerator.Current.ToString() + "\n";
            }
            return result.Remove(result.Length - 1);
        }

        /// <summary>
        /// сортировка персонажей
        /// </summary>
        /// <param name="list">список персонажей</param>
        /// <param name="length">длинна списка</param>
        /// <returns>список отсортированных персонажей</returns>
        private List<string> Sort(List<string> list, int length)
        {
            bool isRecord = true;
            List<string> result = new List<string>();
            result.Clear();
            for (int i = 0; i < length; i++)
            {
                IEnumerator characters = list.GetEnumerator();
                while (characters.MoveNext())
                {
                    string[] characterAttributes = characters.Current.ToString().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    if(isRecord)
                    {
                        result.Add(characters.Current.ToString());
                        isRecord = false;
                    }
                    string[] attributes = result[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                    string[] characterTime = characterAttributes[2].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] time = attributes[2].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    if(((int.Parse(characterTime[0]) * 3600) + (int.Parse(characterTime[1]) * 60) + (int.Parse(characterTime[2]))) < ((int.Parse(time[0]) * 3600) + (int.Parse(time[1]) * 60) + (int.Parse(time[2]))))
                    {
                        if (i == 0)
                        {
                            result[i] = characters.Current.ToString();
                        }
                        else
                        {
                            string[] resultAttributes = result[i - 1].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                            string[] resultTime = resultAttributes[2].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                            if (((int.Parse(characterTime[0]) * 3600) + (int.Parse(characterTime[1]) * 60) + (int.Parse(characterTime[2]))) != ((int.Parse(resultTime[0]) * 3600) + (int.Parse(resultTime[1]) * 60) + (int.Parse(resultTime[2]))))
                            {
                                result[i] = characters.Current.ToString();
                            }
                        }
                    }
                }

                isRecord = true;
            }

            return result;
        }
    }
}
