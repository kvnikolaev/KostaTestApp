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
            return DateTime.Now.Year - employee.DateOfBirth.Year;
        }
    }
}
