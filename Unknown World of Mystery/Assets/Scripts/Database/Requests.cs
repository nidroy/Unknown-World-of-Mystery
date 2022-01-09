using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.Sql;
using System.Data.SqlClient;
using System;

public class GetUsers : IRequest
{
    public string Execute(string connectionString)
    {
        List<string> users = new List<string>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT Username FROM User;";

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(reader[0].ToString());
            }
            connection.Close();
        }
        string result = "";
        IEnumerator user = users.GetEnumerator();
        while (user.MoveNext())
        {
            result += user.Current.ToString() + "_";
        }
        return result.Remove(result.Length - 1);
    }
}

public class GetPassword : IRequest
{
    string username;

    public GetPassword(string username)
    {
        this.username = username;
    }

    public string Execute(string connectionString)
    {
        string result = "";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = String.Format("SELECT Password FROM User WHERE Username = '{0}';", username);

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

public class CreateUser : IRequest
{
    string username;
    string password;

    public CreateUser(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public string Execute(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = String.Format("INSERT INTO User VALUES ('{0}','{1}');", username, password);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            connection.Close();
        }
        return "a new user has been created";
    }
}