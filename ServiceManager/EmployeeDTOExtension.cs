using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager
{
    public static class EmployeeDTOExtension
    {
        public static int GetAge(this DALServiceReference.Employee_dto employee)
        {
            int lambda = DateTime.Now.Year - employee.DateOfBirth.Year;
            if (employee.DateOfBirth.AddYears(lambda) > DateTime.Now) lambda--;
            return lambda;
        }
    }
}
