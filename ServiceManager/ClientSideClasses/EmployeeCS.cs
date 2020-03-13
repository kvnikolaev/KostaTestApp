using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServiceManager.ClientSideClasses
{
    public class EmployeeCS : EntityBase
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Имя должно быть указано")]
        [StringLength(50, ErrorMessage = "Длина имени максимум 50 сиволов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия должна быть указана")]
        [StringLength(50, ErrorMessage = "Длина фамилии максимум 50 символов")]
        public string SurName { get; set; }

        [StringLength(50, ErrorMessage = "Длина отчества максимум 50 символов")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Дата рождения должна быть указана")]
        public System.DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }

        [StringLength(4, ErrorMessage = "Серия документа должна быть не длинее 4 символов")]
        public string DocSeries { get; set; }

        [StringLength(6, ErrorMessage = "Номер документа должен быть не длинее 6 символов")]
        public string DocNumber { get; set; }

        [Required(ErrorMessage = "Должность должна быть указана")]
        [StringLength(50, ErrorMessage = "Длина указаной позиции максимум 50 сиволов")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Подразделение должно быть указано")]
        [CustomValidation(typeof(EmployeeCS), "GuidEmptyCheck")]
        public System.Guid? DepartmentID { get; set; }

        public DepartmentCS Department { get; set; }


        public static ValidationResult GuidEmptyCheck(System.Guid? guid, ValidationContext context)
        {
            if (guid == Guid.Empty)
            {
                return new ValidationResult("Подразделение должно быть указано");
            }

            return ValidationResult.Success;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2}", SurName, FirstName, Position);
        }
    }
}
