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
        public IEnumerable<Department_dto> GetDepartmentStructureWithEmployees()
        {
            return _logic.GetDepartmentStructureWithEmployees();
        }

        public IEnumerable<Employee_dto> GetEmployeeByDepartment(Guid departmentID)
        {
            return _logic.GetEmployeesByDepartment(departmentID);
        }

        public int AddEmployee(Employee_dto employee)
        {
            return _logic.AddEmployee(employee);
        }

        public Guid AddDepartment(Department_dto department)
        {
            return _logic.AddDepartment(department);
        }

        public void EditEmployee(Employee_dto employee)
        {
            _logic.EditEmployee(employee);
        }

        public void EditDepartment(Department_dto department)
        {
            _logic.EditDepartment(department);
        }

        public void DeleteEmployee(Employee_dto employee)
        {
            _logic.DeleteEmployee(employee);
        }

        public void DeleteDepartment(Department_dto department)
        {
            _logic.DeleteDepartment(department);
        }
    }
}
