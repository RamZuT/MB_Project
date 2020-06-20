using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MB.WCF.DataContract
{
    public class DCUnionDetallePresupuesto
    {
        [DataMember]
        public int iIdUnion { get; set; }
        [DataMember]
        public int iIdDetalle { get; set; }
        [DataMember]
        public int iIdPresupuesto { get; set; }

    }
}