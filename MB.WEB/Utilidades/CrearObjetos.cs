using MB.WCF.DataContract;
using MB.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WEB.Utilidades
{
    public class CrearObjetos
    {
        WCF.DataContract.DCIngresos dcingresoR = new WCF.DataContract.DCIngresos();
        WCF.DataContract.DCIngresos ultimoIngreso = new WCF.DataContract.DCIngresos();
        WCF.DataContract.DCHisTipoCambio tipoCambio = new WCF.DataContract.DCHisTipoCambio();
        DCGastos dcGasto = new DCGastos();

        public DCHisTipoCambio crearTipoCambioParcial(int idMoneda, decimal? monto, DateTime fecha)
        {
            if (idMoneda == 1)
            {
                tipoCambio.iIdMoneda = idMoneda;
                tipoCambio.vMonto = Convert.ToDecimal(monto);
                tipoCambio.dFecha = fecha;
            }
            else
            {
                tipoCambio.iIdMoneda = idMoneda;
                tipoCambio.vMonto = 1;
                tipoCambio.dFecha = fecha;
            }
            return tipoCambio;
        }

        public DCIngresos crearIngreso(decimal monto, DateTime fecha, string concepto)
        {
            if (!monto.Equals(null) || !fecha.Equals(null) || !concepto.Equals(null))
            {
                dcingresoR.dMonto = monto;
                dcingresoR.dFecha = fecha;
                dcingresoR.vConcepto = concepto;
            }
            return dcingresoR;
        }

        public DCGastos crearGasto(int iIdCatalogo, decimal dMonto, DateTime dFecha, string vDetalle, int iIdFormaPago)
        {
            if (!iIdCatalogo.Equals(null) || !dMonto.Equals(null) || !dFecha.Equals(null) || !iIdFormaPago.Equals(null))
            {
                dcGasto.iIdCatalogo = iIdCatalogo;
                dcGasto.dMonto = dMonto;
                dcGasto.dFecha = dFecha;
                dcGasto.vDetalle = vDetalle;
                dcGasto.iIdFormaPago = iIdFormaPago;
            }
            return dcGasto;
        }
    }
}
