using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MB.WCF.DataContract
{
    public class DCFormaPago
    {
        [DataMember]
        public int iIdFormaPago { get; set; }
        [DataMember]
        public string vDetalleFP { get; set; }

    }
}