using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MB.WEB.Models
{
    public class IngresosRegistrar
    {
        public int iIdIngresos { get; set; }

        [Required]
        [Display(Name = "Monto")]
        public decimal dMonto { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime dFecha { get; set; }

        [Display(Name = "Concepto")]
        public string vConcepto { get; set; }

        [Display(Name = "Moneda")]
        public int iMoneda { get; set; }
    }
}
