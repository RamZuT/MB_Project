using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MB.WCF.DataContract
{
    public class DCCatalogo
    {
        [DataMember]
        public int iIdCatalogo { get; set; }
        [DataMember]
        public string vDetalle { get; set; }
    }
}