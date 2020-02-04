using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALService.DTO
{
    public class Department_dto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public System.Guid ParentDepartmentID { get; set; }
        public IEnumerable<Department_dto> ChildDepartments { get; set; }
        public IEnumerable<Employee_dto> Empoyee { get; set; }
    }
}
