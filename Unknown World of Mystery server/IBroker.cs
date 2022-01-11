using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unknown_World_of_Mystery_server
{
    public interface IBroker
    {
        /// <summary>
        /// формирование ответа в зависимости от полученного сообщения
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <returns>ответ</returns>
        string FormResponse(string message);
    }
}
