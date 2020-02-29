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

        public int AddEmployee(Employee_dto employee)
        {
            return _logic.AddEmployee(employee);
        }

        public int AddDepartment(Department_dto department)
        {
            return _logic.AddDepartment(department);
        }
    }
}
