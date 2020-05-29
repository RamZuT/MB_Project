using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Acciones
{
    public class AccionIngresos
    {
        public void registroIngresos(DCIngresos dcIngresos)
        {
            using (var context = new MBEntities())
            {
                context.INGRESOS.Add(new INGRESOS
                {
                dFecha = dcIngresos.dFecha,
                iMoneda = dcIngresos.iMoneda,
                dMonto = dcIngresos.dMonto,
                vConcepto = dcIngresos.vConcepto,
                });
                context.SaveChanges();
            }
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
                DCIngresos.iMoneda = Convert.ToInt32(Ingresos.iMoneda);
            }
            return DCIngresos;
        }
    }
}