using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MB.WCF.DataContract
{
    public class CDHisCapitalFinanciero
    {
        [DataMember]
        public int iIdCapitalF { get; set; }
        [DataMember]
        public double vMontoCF { get; set; }
        [DataMember]
        public DateTime dFechaDeCorte { get; set; }
        [DataMember]
        public bool bEstado { get; set; }
    }
}