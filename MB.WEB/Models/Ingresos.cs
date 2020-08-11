using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WEB.Models
{
    public class Ingresos
    {
        public int? iIdIngresos { get; set; }
        public decimal dMonto { get; set; }
        public DateTime dFecha { get; set; }
        public string vConcepto { get; set; }
    }
}