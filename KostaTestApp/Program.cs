using KostaTestApp.DALServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary;

namespace KostaTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WCFhost host = new WCFhost();
            host.OnStart();
        }
    }
}
