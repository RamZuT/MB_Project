using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MB.WCF.DataContract
{
    public class DCCategorias
    {
        [DataMember]
        public int iIdCategoria { get; set; }
        [DataMember]
        public string vDetalle { get; set; }
    }
}