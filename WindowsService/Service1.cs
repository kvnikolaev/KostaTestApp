using ServiceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        WCFhost host;
        public Service1()
        {
            InitializeComponent();
            host = new WCFhost();
        }

        protected override void OnStart(string[] args)
        {
            host.OnStart();
        }

        protected override void OnStop()
        {
            host.OnStop();
        }
    }
}
