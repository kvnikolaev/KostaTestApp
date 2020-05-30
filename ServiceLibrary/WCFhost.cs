using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class WCFhost
    {
        ServiceHost host;
        public void OnStart()
        {
            host = new ServiceHost(typeof(DALService.DALService));
            host.Open();
        }

        public void OnStop()
        {
            //host.Close();
        }
    }
}
