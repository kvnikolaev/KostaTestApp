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
        

        public async Task<IEnumerable<DepartmentCS>> GetDepartmentStructureWithEmployees()
        {
            _client = new DALServiceClient();
            var t = await _client.GetDepartmentStructureWithEmployeesAsync();//.AsEnumerable();
            _client.Close();
            return _mapper.Map<IEnumerable<DepartmentCS>>(t);
        }

        public async Task<IEnumerable<EmployeeCS>> GetEmployeesByDepartment(Guid departmentID)
        {
            _client = new DALServiceClient();
            var t = await _client.GetEmployeeByDepartmentAsync(departmentID);
            _client.Close();
            return _mapper.Map<IEnumerable<EmployeeCS>>(t);
        }

        public async Task<int> AddEmployee(EmployeeCS employee)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Employee_dto>(employee);
            var result = await _client.AddEmployeeAsync(t);
            _client.Close();
            return result;
        }

        public async Task<Guid> AddDepartment(DepartmentCS department)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Department_dto>(department);
            var result = await _client.AddDepartmentAsync(t);
            _client.Close();
            return result;
        }

        public async Task EditEmployee(EmployeeCS employee)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Employee_dto>(employee);
            await _client.EditEmployeeAsync(t);
            _client.Close();
        }

        public async Task EditDepartment(DepartmentCS department)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Department_dto>(department);
            await _client.EditDepartmentAsync(t);
            _client.Close();
        }

        public async Task DeleteEmployee(EmployeeCS employee)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Employee_dto>(employee);
            await _client.DeleteEmployeeAsync(t);
            _client.Close();
        }

        public async Task DeleteDepartment(DepartmentCS department)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Department_dto>(department);
            await _client.DeleteDepartmentAsync(t);
            _client.Close();
        }
    }
}
