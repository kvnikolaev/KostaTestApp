using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceManager;
using System.Configuration;

namespace UIClient
{
    public class ConfigLoader : IConnectionStringLoader
    {
        public Dictionary<string, string> GetConnectionStrings()
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
            foreach (ConnectionStringSettings t in ConfigurationManager.ConnectionStrings)
            {
                res.Add(t.Name, t.ConnectionString);
            }
            return res;
        }

        public void SaveConnectionString(string connectionString)
        {
            var newString = new ConnectionStringSettings("defaultHome", connectionString);

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStrings = configFile.ConnectionStrings.ConnectionStrings;

            connectionStrings.Clear();
            connectionStrings.Add(newString);
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.ConnectionStrings.SectionInformation.Name);
        }
    }
}
