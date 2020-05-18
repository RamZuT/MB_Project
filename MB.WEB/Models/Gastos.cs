using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WEB.Models
{
    public class Gastos
    {
        public int iIdGastos { get; set; }
        public int iIdCategoria { get; set; }
        public double dMonto { get; set; }
        public DateTime dFecha { get; set; }
        public int iIdMoneda { get; set; }
        public string vDetalle { get; set; }
        public int iIdFormaPago { get; set; }
    }
}