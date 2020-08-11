using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MB.WCF.DataContract
{
    public class DCUnion_HisCap_Gasto
    {
        [DataMember]
        public int iIdCapitalF { get; set; }
        [DataMember]
        public int iIGastos { get; set; }
        [DataMember]
        public int iIdHCP_INGAS { get; set; }
    }
}