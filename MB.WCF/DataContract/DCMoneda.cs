using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MB.WCF.DataContract
{
    public class DCMoneda
    {
        [DataMember]
        public int iIdMoneda { get; set; }
        [DataMember]
        public string vCodMoneda { get; set; }
        [DataMember]
        public string vMoneda { get; set; }
    }
}