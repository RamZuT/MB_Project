using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MB.WCF.DataContract
{
    public class DCIngresos
    {
        [DataMember]
        public int iIdIngresos { get; set; }
        [DataMember]
        public decimal dMonto { get; set; }
        [DataMember]
        public DateTime dFecha { get; set; }
        [DataMember]
        public string vConcepto { get; set; }
    }
}