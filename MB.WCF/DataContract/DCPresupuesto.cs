using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MB.WCF.DataContract
{
    public class DCPresupuesto
    {
        [DataMember]
        public int iIdPresupuesto { get; set; }
        [DataMember]
        public DateTime dFechaInicio { get; set; }
        [DataMember]
        public DateTime dFechaFinal { get; set; }
        [DataMember]
        public decimal? dMontoPresupuesto { get; set; }
        [DataMember]
        public decimal? dMontoReal { get; set; }

    }
}