using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DALService.DTO;

namespace DALService
{
    public class DALService : IDALService
    {
        private readonly ServiceLogic _logic = new ServiceLogic();
        public IEnumerable<Department_dto> GetDepartmentStructureWithEmployees(string connectionString)
        {
            return _logic.GetDepartmentStructureWithEmployees(connectionString);
        }

        public IEnumerable<Employee_dto> GetEmployeeByDepartment(Guid departmentID, string connectionString)
        {
            return _logic.GetEmployeesByDepartment(departmentID, connectionString);
        }

        public int AddEmployee(Employee_dto employee, string connectionString)
        {
            return _logic.AddEmployee(employee, connectionString);
        }

        public Guid AddDepartment(Department_dto department, string connectionString)
        {
            return _logic.AddDepartment(department, connectionString);
        }

        public void EditEmployee(Employee_dto employee, string connectionString)
        {
            _logic.EditEmployee(employee, connectionString);
        }

        public void EditDepartment(Department_dto department, string connectionString)
        {
            _logic.EditDepartment(department, connectionString);
        }

        public void DeleteEmployee(Employee_dto employee, string connectionString)
        {
            _logic.DeleteEmployee(employee, connectionString);
        }

        public void DeleteDepartment(Department_dto department, string connectionString)
        {
            _logic.DeleteDepartment(department, connectionString);
        }
    }
}
