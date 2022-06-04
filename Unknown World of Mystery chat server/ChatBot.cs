using System.Data.SqlClient;

namespace Unknown_World_of_Mystery_chat_server
{
    public class ChatBot
    {
        public static string pathToDatabase = Environment.CurrentDirectory + "\\Database\\Unknown World of Mystery database.mdf"; // путь к бд 
        public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + pathToDatabase + ";Integrated Security=True;Connect Timeout=30";

        public static string FormResponse(string message)
        {
            message = message.Remove(0, 1);
            string result = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = String.Format("SELECT [Response] FROM [ChatBot] WHERE [Message] = '{0}';", message);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = reader[0].ToString();
                }
                
                connection.Close();
            }
            return result;
        }
    }
}
