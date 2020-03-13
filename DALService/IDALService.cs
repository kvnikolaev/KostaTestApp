using DALService.DTO;
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
        IEnumerable<Department_dto> GetDepartmentStructureWithEmployees();

        [OperationContract]
        int AddEmployee(Employee_dto employee);

        [OperationContract]
        Guid AddDepartment(Department_dto department);

        [OperationContract]
        void EditEmployee(Employee_dto employee);

        [OperationContract]
        void EditDepartment(Department_dto department);

        [OperationContract]
        void DeleteEmployee(Employee_dto employee);

        [OperationContract]
        void DeleteDepartment(Department_dto department);
    }

    
}
