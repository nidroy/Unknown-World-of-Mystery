using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unknown_World_of_Mystery_server
{
    public class Database
    {
        public string connectionString = "Data Source=MYCOMPUTER;Initial Catalog='Unknown World of Mystery database';Integrated Security=True";

        public Dictionary<string, IQuery> queryDictionary = new Dictionary<string, IQuery>();
        List<IQuery> query = new List<IQuery>();

        public Database(IQuery GetUsernames, IQuery GetPassword, IQuery CreateUser)
        {
            query.Add(GetUsernames);
            query.Add(GetPassword);
            query.Add(CreateUser);
        }

        public void FillInTheDueryDictionary()
        {
            queryDictionary.Clear();
            queryDictionary.Add("GetUsernames", query[0]);
            queryDictionary.Add("GetPassword", query[1]);
            queryDictionary.Add("CreateUser", query[2]);
        }

        public string ExecuteQuery(string query)
        {
            return queryDictionary[query].Execute(connectionString);
        }
    }
}
