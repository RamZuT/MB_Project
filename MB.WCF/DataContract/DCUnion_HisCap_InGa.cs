﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MB.WCF.DataContract
{
    public class DCUnion_HisCap_InGa
    {
        [DataMember]
        public int iIdCapitalF { get; set; }
        [DataMember]
        public int? iIdIngreso { get; set; }
        [DataMember]
        public int iIdHCP_INGAS { get; set; }

    }
}