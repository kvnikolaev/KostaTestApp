using ServiceManager.DALServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServiceManager.ClientSideClasses
{
    /// <summary>
    /// Client Side версия dto
    /// </summary>
    public class DepartmentCS : EntityBase
    {
        public System.Guid ID { get; set; }

        [Required(ErrorMessage = "Необходимо указать наименование подразделения")]
        [StringLength(50, ErrorMessage = "Длина наименования максимум 50 символов")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "Длина мнемокода максимум 10 символов")]
        public string Code { get; set; }

        public System.Guid? ParentDepartmentID { get; set; }

        public IEnumerable<DepartmentCS> ChildDepartments { get; set; }
        public IEnumerable<EmployeeCS> Employee { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
