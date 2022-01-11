using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unknown_World_of_Mystery_server
{
    public interface IQuery
    {
        string Execute(string connectionString);
    }
}
