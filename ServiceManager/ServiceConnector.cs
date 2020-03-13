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
        IMapper _mapper;

        public ServiceConnector()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = config.CreateMapper();
        }
        

        public IEnumerable<DepartmentCS> GetDepartmentStructureWithEmployees()
        {
            _client = new DALServiceClient();
            var t = _client.GetDepartmentStructureWithEmployees().AsEnumerable();
            _client.Close();
            return _mapper.Map<IEnumerable<DepartmentCS>>(t);
        }

        public int AddEmployee(EmployeeCS employee)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Employee_dto>(employee);
            var result = _client.AddEmployee(t);
            _client.Close();
            return result;
        }

        public Guid AddDepartment(DepartmentCS department)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Department_dto>(department);
            var result = _client.AddDepartment(t);
            _client.Close();
            return result;
        }

        public void EditEmployee(EmployeeCS employee)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Employee_dto>(employee);
            _client.EditEmployee(t);
            _client.Close();
        }

        public void EditDepartment(DepartmentCS department)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Department_dto>(department);
            _client.EditDepartment(t);
            _client.Close();
        }

        public void DeleteEmployee(EmployeeCS employee)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Employee_dto>(employee);
            _client.DeleteEmployee(t);
            _client.Close();
        }

        public void DeleteDepartment(DepartmentCS department)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Department_dto>(department);
            _client.DeleteDepartment(t);
            _client.Close();
        }
    }
}
