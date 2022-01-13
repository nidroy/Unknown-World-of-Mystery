using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;

namespace Unknown_World_of_Mystery_server
{
    public class QueryGetUsernames : IQuery
    {
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

    public class QueryGetPassword : IQuery
    {
        string[] user;

        public QueryGetPassword(string[] user)
        {
            this.user = user;
        }

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

    public class QueryCreateUser : IQuery
    {
        string[] user;

        public QueryCreateUser(string[] user)
        {
            this.user = user;
        }

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

    public class QueryGetCharacters : IQuery
    {
        string[] user;

        public QueryGetCharacters(string[] user)
        {
            this.user = user;
        }

        public string Execute(string connectionString)
        {
            List<string> characters = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("SELECT [Name], [Level], [TimeInTheGame] FROM [Character] JOIN [User] ON [Character].[UserID] = [User].[ID] WHERE [Username] = '{0}';", user[1]);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    characters.Add(String.Format("{0}-{1}-{2}", reader[0], reader[1], reader[2]));
                }
                connection.Close();
            }
            IEnumerator character = characters.GetEnumerator();
            string result = "";
            while (character.MoveNext())
            {
                result += character.Current.ToString() + "_";
            }
            return result.Remove(result.Length - 1);
        }
    }

    public class QueryCreateCharacter : IQuery
    {
        string[] character;

        public QueryCreateCharacter(string[] character)
        {
            this.character = character;
        }

        public string Execute(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("INSERT INTO [Character] VALUES((SELECT [ID] FROM [User] WHERE [Username] = '{0}'),'{1}','{2}','0');", character[1], character[2], character[3]);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
            return "the character is created";
        }
    }

    public class QueryGetSettings : IQuery
    {
        string[] user;

        public QueryGetSettings(string[] user)
        {
            this.user = user;
        }

        public string Execute(string connectionString)
        {
            string settings = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("SELECT [ScreenResolution], [VolumeOfSounds], [ScreenMode], [VolumeMusic] FROM [Settings] JOIN [User] ON [Settings].[UserID] = [User].[ID] WHERE [Username] = '{0}';", user[1]);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    settings = String.Format("{0}-{1}-{2}-{3}", reader[0], reader[1], reader[2], reader[3]);
                }
                connection.Close();
            }
            return settings;
        }
    }
}
