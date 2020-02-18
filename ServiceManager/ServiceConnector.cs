using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ServiceManager.ClientSideClasses;
using ServiceManager.DALServiceReference;

namespace ServiceManager
{
    public class ServiceConnector
    {
        private DALServiceClient _client;
        MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());

        public IEnumerable<DepartmentCS> GetDepartmentStructureWithEmployees()
        {
            _client = new DALServiceClient();
            var t = _client.GetDepartmentStructureWithEmployees().AsEnumerable();
            return config.CreateMapper().Map<IEnumerable<DepartmentCS>>(t);
        }
    }
}
