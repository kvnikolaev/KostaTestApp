using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DALService.ServiceFaults
{
    [DataContract]
    public class DefaultFault
    {
        [DataMember]
        public string Message { get; set; }

        public DefaultFault(string message)
        {
            this.Message = message;
        }
    }
}
