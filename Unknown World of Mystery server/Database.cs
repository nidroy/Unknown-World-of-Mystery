using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unknown_World_of_Mystery_server
{
    public class Database
    {
        const string connectionString = "Data Source=MYCOMPUTER;Initial Catalog='Unknown World of Mystery database';Integrated Security=True";

        public Dictionary<string, IQuery> queryDictionary = new Dictionary<string, IQuery>();
        List<IQuery> query = new List<IQuery>();

        public Database(IQuery GetUsernames, IQuery GetPassword, IQuery CreateUser, IQuery GetCharacters, IQuery CreateCharacter, IQuery GetSettings)
        {
            query.Add(GetUsernames);
            query.Add(GetPassword);
            query.Add(CreateUser);
            query.Add(GetCharacters);
            query.Add(CreateCharacter);
            query.Add(GetSettings);
        }

        public void FillInTheQueryDictionary()
        {
            queryDictionary.Clear();
            queryDictionary.Add("GetUsernames", query[0]);
            queryDictionary.Add("GetPassword", query[1]);
            queryDictionary.Add("CreateUser", query[2]);
            queryDictionary.Add("GetCharacters", query[3]);
            queryDictionary.Add("CreateCharacter", query[4]);
            queryDictionary.Add("GetSettings", query[5]);
        }

        public string ExecuteQuery(string query)
        {
            return queryDictionary[query].Execute(connectionString);
        }
    }
}
