﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unknown_World_of_Mystery_server
{
    /// <summary>
    /// класс для запросов к бд
    /// </summary>
    public class Database
    {
        // строка подключения к бд на пк
        const string connectionString = "Data Source=MYCOMPUTER;Initial Catalog='Unknown World of Mystery database';Integrated Security=True";
        // строка подключения к бд на ноуте
        //const string connectionString = "Data Source=MYLAPTOP;Initial Catalog='Unknown World of Mystery database';Integrated Security=True";

        /// <summary>
        /// словарь запросов
        /// </summary>
        public Dictionary<string, IQuery> queryDictionary = new Dictionary<string, IQuery>();
        List<IQuery> query = new List<IQuery>();// запросы

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="GetUsernames">запрос на получения имени пользователя</param>
        /// <param name="GetPassword">запрос на получения пароля пользователя</param>
        /// <param name="CreateUser">запрос на создания пользователя</param>
        /// <param name="GetCharacters">запрос на получения персонажей</param>
        /// <param name="CreateCharacter">запрос на создания персонажа</param>
        /// <param name="GetCharacterNames">запрос на получения имен персонажей</param>
        public Database(IQuery GetUsernames, IQuery GetPassword, IQuery CreateUser, IQuery GetCharacters, IQuery CreateCharacter, IQuery GetCharacterNames)
        {
            query.Add(GetUsernames);
            query.Add(GetPassword);
            query.Add(CreateUser);
            query.Add(GetCharacters);
            query.Add(CreateCharacter);
            query.Add(GetCharacterNames);
        }

        /// <summary>
        /// заполнения словаря
        /// </summary>
        public void FillInTheQueryDictionary()
        {
            queryDictionary.Clear();
            queryDictionary.Add("GetUsernames", query[0]);
            queryDictionary.Add("GetPassword", query[1]);
            queryDictionary.Add("CreateUser", query[2]);
            queryDictionary.Add("GetCharacters", query[3]);
            queryDictionary.Add("CreateCharacter", query[4]);
            queryDictionary.Add("GetCharacterNames", query[5]);
        }

        /// <summary>
        /// выполнение запроса
        /// </summary>
        /// <param name="query">запрос</param>
        /// <returns>ответ на запрос</returns>
        public string ExecuteQuery(string query)
        {
            return queryDictionary[query].Execute(connectionString);
        }
    }
}
