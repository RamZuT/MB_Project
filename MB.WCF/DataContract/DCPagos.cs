using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MB.WCF.DataContract
{
    public class DCPagos
    {
        [DataMember]
        public int iIdPagos { get; set; }
        [DataMember]
        public DateTime dFechaVencePago { get; set; }
        [DataMember]
        public double dMonto { get; set; }
        [DataMember]
        public bool  bEstado { get; set; }
        [DataMember]
        public int iIdCatalogo { get; set; }
    }
}