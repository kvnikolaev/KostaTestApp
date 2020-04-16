using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALService.EDM
{
    public partial class TestDBEntities
    {
        private TestDBEntities(string connectionString)
            : base(connectionString)
        {

        }

        /// <summary>
        /// Создает DbContext на основе переданного data source, дополняя его необходимой строкой подключения
        /// </summary>
        /// <param name="dataSource">data source состовляющая строки подключения</param>
        public static TestDBEntities FactoryMethod(string dataSource)
        {
            string connectionString = "metadata=res://*/EDM.TestDBModel.csdl|" +
                                               "res://*/EDM.TestDBModel.ssdl|" +
                                               "res://*/EDM.TestDBModel.msl;" +
                                      "provider=System.Data.SqlClient;" +
                                      "provider connection string='" +
                                      dataSource +
                                      ";App=EntityFramework'";

            return new TestDBEntities(connectionString);
        }

    }
}
