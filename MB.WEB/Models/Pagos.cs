using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WEB.Models
{
    public class Pagos
    {
        public int iIdPagos { get; set; }
        public string vConcepto { get; set; }
        public DateTime dFechaVencePago { get; set; }
        public double dMonto { get; set; }
        public bool bEstado { get; set; }
        public int iIdCategoria { get; set; }
    }
}