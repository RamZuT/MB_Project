using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MB.WCF.DataContract
{
    public class DCGastos
    {
        [DataMember]
        public int iIdGastos { get; set; }
        [DataMember]
        public int iIdCatalogo { get; set; }
        [DataMember]
        public double dMonto { get; set; }
        [DataMember]
        public DateTime dFecha { get; set; }
        [DataMember]
        public int iIdTipoCambio { get; set; }
        [DataMember]
        public string vDetalle { get; set; }
        [DataMember]
        public int iIdFormaPago { get; set; }
    }
}