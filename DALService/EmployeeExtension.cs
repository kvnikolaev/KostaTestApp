using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALService
{
    public static class EmployeeExtension
    {
        public static int GetAge(this EDM.Employee employee)
        {
            int lambda = DateTime.Now.Year - employee.DateOfBirth.Year;
            if (employee.DateOfBirth.AddYears(lambda) > DateTime.Now) lambda--;
            return lambda;
        }
    }
}
