using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager
{
    public interface IConnectionStringLoader
    {
        /// <summary>
        /// Возвращает словарь, где ключ - имя строки подключения
        /// </summary>
        /// <returns>Возвращает словарь, где ключ - имя строки подключения</returns>
        Dictionary<string, string> GetConnectionStrings();
        void SaveConnectionString(string connectionString);
    }
}
