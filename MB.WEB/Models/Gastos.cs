using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MB.WEB.Models
{
    public class Gastos
    {
        public int iIdGastos { get; set; }

        [Display(Name = "Catálogo")]
        public int iIdCategoria { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números.")]
        [Display(Name = "Monto")]
        public double dMonto { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime dFecha { get; set; }

        [Display(Name = "Moneda")]
        public int iIdMoneda { get; set; }

        [Display(Name = "Detalle")]
        public string vDetalle { get; set; }

        [Display(Name = "Forma de pago")]
        public int iIdFormaPago { get; set; }
    }
}