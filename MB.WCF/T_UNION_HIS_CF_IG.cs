//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MB.WCF
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_UNION_HIS_CF_IG
    {
        public int iIdCapitalF { get; set; }
        public int iIdIngreso { get; set; }
        public int iIdHCP_INGAS { get; set; }
    
        public virtual HIS_CAPITAL_FINANCIERO HIS_CAPITAL_FINANCIERO { get; set; }
        public virtual INGRESOS INGRESOS { get; set; }
    }
}
