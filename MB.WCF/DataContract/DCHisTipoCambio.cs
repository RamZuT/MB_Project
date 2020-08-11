using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MB.WCF.DataContract
{
    public class DCHisTipoCambio
    {
        [DataMember]
        public int iIdTipoCambio { get; set; }
        [DataMember]
        public decimal vMonto { get; set; }
        [DataMember]
        public DateTime dFecha { get; set; }
        [DataMember]
        public int iIdMoneda { get; set; }
        [DataMember]
        public int iIdIngreso { get; set; }
        [DataMember]
        public int iIdGasto { get; set; }
    }
}