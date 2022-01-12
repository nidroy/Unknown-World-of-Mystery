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
    public class GetUsernames : IQuery
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

    public class GetPassword : IQuery
    {
        string[] user;

        public GetPassword(string[] user)
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

    public class CreateUser : IQuery
    {
        string[] user;

        public CreateUser(string[] user)
        {
            this.user = user;
        }

        public string Execute(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("INSERT INTO User VALUES('{0}','{1}');", user[1], user[2]);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
            return "user created";
        }
    }
}
