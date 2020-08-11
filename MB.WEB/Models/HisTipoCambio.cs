using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WEB.Models
{
    public class HisTipoCambio
    {
        public int iIdTipoCambio { get; set; }
        public decimal? vMonto { get; set; }
        public DateTime dFecha { get; set; }
        public int iIdMoneda { get; set; }
        public int iIdGasto { get; set; }
        public int iIdIngreso { get; set; }
    }
}