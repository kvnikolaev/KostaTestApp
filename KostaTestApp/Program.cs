using KostaTestApp.DALServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KostaTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new DALServiceClient();
            var t = client.GetDepartmentStructureWithEmployees();
        }
    }
}
