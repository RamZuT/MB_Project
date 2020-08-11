using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Acciones
{
    public class AccionIngresos
    {
        public bool registroIngresos(DCIngresos dcIngresos)
        {
            bool resultado = false;
            using (var context = new MBEntities())
            {
                context.INGRESOS.Add(new INGRESOS
                {
                dFecha = dcIngresos.dFecha,
                dMonto = dcIngresos.dMonto,
                vConcepto = dcIngresos.vConcepto,
                });
                resultado = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
            }
            return resultado;
        }

        public DCIngresos obtenerUltimoIngreso()
        {
            DCIngresos DCIngresos = new DCIngresos();
            using (var context = new MBEntities())
            {
                var Ingresos = (from INGRESOS in context.INGRESOS
                                   orderby INGRESOS.iIdIngreso
                                   descending
                                   select INGRESOS).FirstOrDefault();
                DCIngresos.iIdIngresos = Ingresos.iIdIngreso;
                DCIngresos.dMonto = Ingresos.dMonto;
                DCIngresos.dFecha = Ingresos.dFecha;
                DCIngresos.vConcepto = Ingresos.vConcepto;
            }
            return DCIngresos;
        }
        public bool eliminarIngresoPorId(int idIngreso)
        {
            INGRESOS Ingresos = new INGRESOS();
            bool resultado = false;
            using (var context = new MBEntities())
            {
                var registro = (from _INGRESOS in context.INGRESOS
                                where _INGRESOS.iIdIngreso == idIngreso
                                select _INGRESOS).FirstOrDefault();
                if (registro != null)
                {
                    context.INGRESOS.Remove(registro);
                    resultado = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
                }
            }
            return resultado;
        }

        public bool registroUnionIngreso(int ingreso, int capital)
        {
            bool resultado = false;
            using (var context = new MBEntities())
            {
                context.T_UNION_HIS_CF_IG.Add(new T_UNION_HIS_CF_IG
                {
                    iIdIngreso = ingreso,
                    iIdCapitalF = capital
                });
                resultado = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
            }
            return resultado;
        }
    }
}