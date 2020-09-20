using MB.WCF.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WCF.Logica.Acciones
{
    public class AccionTipoCambio
    {
        public bool guardarTipoCambio(DCHisTipoCambio dcHisTipoCambio, MBEntities context)
        {
            bool resultado = false;
            using (context)
            {
                if (dcHisTipoCambio.iIdIngreso != 0)
                {
                    context.HIS_TIPO_CAMBIO.Add(new HIS_TIPO_CAMBIO
                    {
                        vMonto = dcHisTipoCambio.vMonto,
                        dFecha = dcHisTipoCambio.dFecha,
                        iIdMoneda = dcHisTipoCambio.iIdMoneda,
                        iIdIngreso = dcHisTipoCambio.iIdIngreso
                    });
                    resultado = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
                }
                else
                {
                    context.HIS_TIPO_CAMBIO.Add(new HIS_TIPO_CAMBIO
                    {
                        vMonto = dcHisTipoCambio.vMonto,
                        dFecha = dcHisTipoCambio.dFecha,
                        iIdMoneda = dcHisTipoCambio.iIdMoneda,
                        iIdGasto = dcHisTipoCambio.iIdGasto
                    });
                    resultado = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
                }

            }
            return resultado;
        }

        public bool registroTipoCambio(DCHisTipoCambio dcHisTipoCambio)
        {
            bool resultado = false;
            using (var context = new MBEntities())
            {
                if (dcHisTipoCambio.iIdIngreso != 0)
                {
                    context.HIS_TIPO_CAMBIO.Add(new HIS_TIPO_CAMBIO
                    {
                        vMonto = dcHisTipoCambio.vMonto,
                        dFecha = dcHisTipoCambio.dFecha,
                        iIdMoneda = dcHisTipoCambio.iIdMoneda,
                        iIdIngreso = dcHisTipoCambio.iIdIngreso
                    });
                    resultado = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
                }
                else
                {
                    context.HIS_TIPO_CAMBIO.Add(new HIS_TIPO_CAMBIO
                    {
                        vMonto = dcHisTipoCambio.vMonto,
                        dFecha = dcHisTipoCambio.dFecha,
                        iIdMoneda = dcHisTipoCambio.iIdMoneda,
                        iIdGasto = dcHisTipoCambio.iIdGasto
                    });
                    resultado = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
                }

            }
            return resultado;
        }

        public int obtenerUltimoIdTipoCambio()
        {
            var iIdTipoCambio = 0;
            using (var context = new MBEntities())
            {
                var UltimoTipoCambio = (from HIS_TIPO_CAMBIO in context.HIS_TIPO_CAMBIO
                                     orderby HIS_TIPO_CAMBIO.iIdTipoCambio
                                     descending
                                     select HIS_TIPO_CAMBIO).FirstOrDefault();
                if (UltimoTipoCambio != null)
                {
                    iIdTipoCambio = UltimoTipoCambio.iIdTipoCambio;
                }
            }
            return iIdTipoCambio;
        }

        public bool eliminarTipoCambioPorId(int idTipoCambio)
        {
            HIS_TIPO_CAMBIO HTipoCambio = new HIS_TIPO_CAMBIO();
            bool resultado = false;
            using (var context = new MBEntities())
            {
                var registro = (from _HIS_TIPO_CAMBIO in context.HIS_TIPO_CAMBIO
                                where _HIS_TIPO_CAMBIO.iIdTipoCambio == idTipoCambio
                                select _HIS_TIPO_CAMBIO).FirstOrDefault();
                if (registro != null)
                {
                    context.HIS_TIPO_CAMBIO.Remove(registro);
                    resultado = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
                }
            }
            return resultado;
        }
    }
}