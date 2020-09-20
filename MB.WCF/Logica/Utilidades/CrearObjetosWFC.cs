using MB.WCF.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WCF.Logica.Utilidades
{
    public class CrearObjetosWFC
    {
        DCUnion_HisCap_InGa unionIngreso = new DCUnion_HisCap_InGa();
        DCHisTipoCambio tipoCambio = new DCHisTipoCambio();
        public DCUnion_HisCap_InGa crearObjetoIngreso(int ingreso, int capital)
        {
            if (!ingreso.Equals(null) || !capital.Equals(null))
            {
                unionIngreso.iIdIngreso = ingreso;
                unionIngreso.iIdCapitalF = capital;
            }
            return unionIngreso;
        }

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
    }
}