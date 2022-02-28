using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;

namespace Unknown_World_of_Mystery_server
{
    /// <summary>
    /// запрос на получения имени пользователя
    /// </summary>
    public class QueryGetUsernames : IQuery
    {
        /// <summary>
        /// выполнение запроса
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        /// <returns></returns>
        public string Execute(string connectionString)
        {
            List<string> usernames = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT [Username] FROM [User];";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usernames.Add(reader[0].ToString());
                }
                connection.Close();
            }
            IEnumerator username = usernames.GetEnumerator();
            string result = "";
            while (username.MoveNext())
            {
                result += username.Current.ToString() + "_";
            }
            return result.Remove(result.Length - 1);
        }
    }

    /// <summary>
    /// запрос на получения пароля
    /// </summary>
    public class QueryGetPassword : IQuery
    {
        string[] user;// имя пользователя
        
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="user">элементы пользователя</param>
        public QueryGetPassword(string[] user)
        {
            this.user = user;
        }

        /// <summary>
        /// выполнение запроса
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        /// <returns>пароль</returns>
        public string Execute(string connectionString)
        {
            string password = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("SELECT [Password] FROM [User] WHERE [Username] = '{0}';", user[1]);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    password = reader[0].ToString();
                }
                connection.Close();
            }
            return password;
        }
    }

    /// <summary>
    /// запрос на создания пользователя
    /// </summary>
    public class QueryCreateUser : IQuery
    {
        string[] user;// имя пользователя и пароль

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="user">элементы пользователя</param>
        public QueryCreateUser(string[] user)
        {
            this.user = user;
        }

        /// <summary>
        /// выполнение запроса
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        /// <returns>подтверждение создания персонажа</returns>
        public string Execute(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("INSERT INTO [User] VALUES('{0}','{1}');", user[1], user[2]);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
            return "user created";
        }
    }

    /// <summary>
    /// запрос на получение персонажей
    /// </summary>
    public class QueryGetCharacters : IQuery
    {
        string[] user;// имя пользователя

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="user">элементы пользователя</param>
        public QueryGetCharacters(string[] user)
        {
            this.user = user;
        }

        /// <summary>
        /// выполнение запроса
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        /// <returns>элементы всех персонажей</returns>
        public string Execute(string connectionString)
        {
            List<string> characters = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("SELECT [Name], [Level], [TimeInTheGame], [Location] FROM [Character] JOIN [User] ON [Character].[UserID] = [User].[ID] WHERE [Username] = '{0}';", user[1]);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    characters.Add(String.Format("{0}-{1}-{2}-{3}", reader[0], reader[1], reader[2], reader[3]));
                }
                connection.Close();
            }
            IEnumerator character = characters.GetEnumerator();
            string result = "";
            while (character.MoveNext())
            {
                result += character.Current.ToString() + "_";
            }
            if(result == "")
            {
                return result;
            }
            return result.Remove(result.Length - 1);
        }
    }

    /// <summary>
    /// запрос на создания персонажа
    /// </summary>
    public class QueryCreateCharacter : IQuery
    {
        string[] character;// имя пользователя, имя персонажа, уровень персонажа

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="character">элементы персонажа</param>
        public QueryCreateCharacter(string[] character)
        {
            this.character = character;
        }

        /// <summary>
        /// выполнение запроса
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        /// <returns>подтверждение создания персонажа</returns>
        public string Execute(string connectionString)
        {   
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("INSERT INTO [Character] VALUES((SELECT [ID] FROM [User] WHERE [Username] = '{0}'),'{1}','{2}','0','1');", character[1], character[2], character[3]);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
            return "the character is created";
        }
    }

    /// <summary>
    /// запрос на получение имен персонажей
    /// </summary>
    public class QueryGetCharacterNames : IQuery
    {
        string[] user;// имя пользователя

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="user">элементы пользователя</param>
        public QueryGetCharacterNames(string[] user)
        {
            this.user = user;
        }

        /// <summary>
        /// выполнение запроса
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        /// <returns>имена персонажей</returns>
        public string Execute(string connectionString)
        {
            string characterNames = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("SELECT [Name] FROM [Character] JOIN [User] ON [Character].[UserID] = [User].[ID] WHERE [Username] = '{0}';", user[1]);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    characterNames += reader[0].ToString() + "_";
                }
                connection.Close();
            }
            if(characterNames == "")
            {
                return characterNames;
            }
            return characterNames.Remove(characterNames.Length - 1);
        }
    }
}
