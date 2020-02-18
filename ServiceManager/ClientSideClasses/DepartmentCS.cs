using ServiceManager.DALServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager.ClientSideClasses
{
    /// <summary>
    /// Client Side версия dto
    /// </summary>
    public class DepartmentCS
    {
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public System.Guid ParentDepartmentID { get; set; }
        public IEnumerable<DepartmentCS> ChildDepartments { get; set; }
        public IEnumerable<EmployeeCS> Employee { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
