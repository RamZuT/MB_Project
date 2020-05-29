using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MB.WCF.DataContract
{
    public class DCHisCapitalFinanciero
    {
        [DataMember]
        public int iIdCapitalF { get; set; }
        [DataMember]
        public decimal dMontoCF { get; set; }
        [DataMember]
        public DateTime dFechaDeCorte { get; set; }
        [DataMember]
        public bool bEstado { get; set; }
        [DataMember]
        public int iIdIngreso { get; set; }
        [DataMember]
        public int iIdGastos { get; set; }
    }
}