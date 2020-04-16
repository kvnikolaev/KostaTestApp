using DALService.DTO;
using DALService.ServiceFaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DALService
{
    [ServiceContract]
    public interface IDALService
    {
        [OperationContract]
        [FaultContract(typeof(DefaultFault))]
        IEnumerable<Department_dto> GetDepartmentStructureWithEmployees(string connectionString);

        [OperationContract]
        [FaultContract(typeof(DefaultFault))]
        IEnumerable<Employee_dto> GetEmployeeByDepartment(Guid departmentID, string connectionString);

        [OperationContract]
        [FaultContract(typeof(DefaultFault))]
        int AddEmployee(Employee_dto employee, string connectionString);

        [OperationContract]
        [FaultContract(typeof(DefaultFault))]
        Guid AddDepartment(Department_dto department, string connectionString);

        [OperationContract]
        [FaultContract(typeof(DefaultFault))]
        void EditEmployee(Employee_dto employee, string connectionString);

        [OperationContract]
        [FaultContract(typeof(DefaultFault))]
        void EditDepartment(Department_dto department, string connectionString);

        [OperationContract]
        [FaultContract(typeof(DefaultFault))]
        void DeleteEmployee(Employee_dto employee, string connectionString);

        [OperationContract]
        [FaultContract(typeof(DefaultFault))]
        void DeleteDepartment(Department_dto department, string connectionString);
    }

    
}
