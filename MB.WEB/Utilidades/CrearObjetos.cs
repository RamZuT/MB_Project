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

        public DCHisTipoCambio crearTipoCambio(int idMoneda, decimal monto, DateTime fecha, int ultimoIngreso, int ultimoGasto)
        {
            if (!idMoneda.Equals(null) || !monto.Equals(null) || !fecha.Equals(null))
            {
                tipoCambio.iIdMoneda = idMoneda;
                tipoCambio.vMonto = monto;
                tipoCambio.dFecha = fecha;
                tipoCambio.iIdIngreso = ultimoIngreso;
                tipoCambio.iIdGasto = ultimoGasto;
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
    }
}
