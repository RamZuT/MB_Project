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
    
    public partial class T_UNION_GAS_DET_PRESUP
    {
        public int iIdUnionGDP { get; set; }
        public Nullable<int> iIdGasto { get; set; }
        public Nullable<int> iIdDetallePresupuesto { get; set; }
    
        public virtual DETALLE_PRESUPUESTO DETALLE_PRESUPUESTO { get; set; }
        public virtual GASTOS GASTOS { get; set; }
    }
}