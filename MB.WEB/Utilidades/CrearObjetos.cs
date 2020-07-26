using MB.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WEB.Utilidades
{
    public class CrearObjetos
    {
        public HisTipoCambio crearTipoCambio(int idMoneda, decimal monto, DateTime fecha)
        {
            HisTipoCambio hisTipoCambio = new HisTipoCambio();
            if (!idMoneda.Equals(null) || !monto.Equals(null) || !fecha.Equals(null))
            {
                hisTipoCambio.iIdMoneda = idMoneda;
                hisTipoCambio.vMonto = monto;
                hisTipoCambio.dFecha = fecha;
            }
            return hisTipoCambio;
        }
    }
}