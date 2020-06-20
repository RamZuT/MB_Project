using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MB.WCF.DataContract
{
    public class DCDetallePresupuesto
    {
        [DataMember]
        public int iIdDetalle { get; set; }
        [DataMember]
        public int iIdCatalogo { get; set; }
        [DataMember]
        public int iIdGasto { get; set; }
        [DataMember]
        public decimal? dMonto { get; set; }

    }
}