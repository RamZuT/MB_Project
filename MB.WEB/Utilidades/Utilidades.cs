using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WEB.Utilidades
{
    public class Utilidades
    {
        public decimal convertirDolarAColon(decimal monto, decimal tipoCambio)
        {
            var resultado = monto * tipoCambio;
            return resultado;
        }
    }
}