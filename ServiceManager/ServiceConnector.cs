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
        private string _defaultConnectionString = "data source=BEST-ПК;initial catalog=TestDB;integrated security=True;MultipleActiveResultSets=True";
        IMapper _mapper;

        private Dictionary<string, string> _connectionStrings; // чтобы потом можно было выбирать строки

        public string CurrentConnectionString { get; set; }

        public bool IsNullConnectionString
        {
            get
            {
                return CurrentConnectionString == null;
                //return _connectionStrings.Count < 1;
            }
        }

        public ServiceConnector(IConnectionStringLoader loader)
        {
            _connectionStrings = loader.GetConnectionStrings();
            CurrentConnectionString = _connectionStrings.FirstOrDefault().Value;

            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            _mapper = config.CreateMapper();
        }
        

        public async Task<IEnumerable<DepartmentCS>> GetDepartmentStructureWithEmployees()
        {
            _client = new DALServiceClient();
            var t = await _client.GetDepartmentStructureWithEmployeesAsync(CurrentConnectionString);
            _client.Close();
            return _mapper.Map<IEnumerable<DepartmentCS>>(t);
        }

        public async Task<IEnumerable<EmployeeCS>> GetEmployeesByDepartment(Guid departmentID)
        {
            _client = new DALServiceClient();
            var t = await _client.GetEmployeeByDepartmentAsync(departmentID, CurrentConnectionString);
            _client.Close();
            return _mapper.Map<IEnumerable<EmployeeCS>>(t);
        }

        public async Task<int> AddEmployee(EmployeeCS employee)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Employee_dto>(employee);
            var result = await _client.AddEmployeeAsync(t, CurrentConnectionString);
            _client.Close();
            return result;
        }

        public async Task<Guid> AddDepartment(DepartmentCS department)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Department_dto>(department);
            var result = await _client.AddDepartmentAsync(t, CurrentConnectionString);
            _client.Close();
            return result;
        }

        public async Task EditEmployee(EmployeeCS employee)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Employee_dto>(employee);
            await _client.EditEmployeeAsync(t, CurrentConnectionString);
            _client.Close();
        }

        public async Task EditDepartment(DepartmentCS department)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Department_dto>(department);
            await _client.EditDepartmentAsync(t, CurrentConnectionString);
            _client.Close();
        }

        public async Task DeleteEmployee(EmployeeCS employee)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Employee_dto>(employee);
            await _client.DeleteEmployeeAsync(t, CurrentConnectionString);
            _client.Close();
        }

        public async Task DeleteDepartment(DepartmentCS department)
        {
            _client = new DALServiceClient();
            var t = _mapper.Map<Department_dto>(department);
            await _client.DeleteDepartmentAsync(t, CurrentConnectionString);
            _client.Close();
        }
    }
}
