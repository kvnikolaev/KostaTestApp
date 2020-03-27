using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DALService.DTO
{
    
    public class Department_dto
    {
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public System.Guid? ParentDepartmentID { get; set; }
        public IEnumerable<Department_dto> ChildDepartments { get; set; }
        public IEnumerable<Employee_dto> Employee { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
