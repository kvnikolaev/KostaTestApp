using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceManager.DALServiceReference;

namespace ServiceManager
{
    public class ServiceConnector
    {
        private DALServiceClient _client;

        public IEnumerable<Department_dto> GetDepartmentStructureWithEmployees()
        {
            _client = new DALServiceClient();
            return _client.GetDepartmentStructureWithEmployees().AsEnumerable();
        }
    }
}
