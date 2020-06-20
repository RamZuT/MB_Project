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
            using (var context = new MBEntities2())
            {
                context.INGRESOS.Add(new INGRESOS
                {
                dFecha = dcIngresos.dFecha,
                iIdTipoCambio = dcIngresos.iIdTipoCambio,
                dMonto = dcIngresos.dMonto,
                vConcepto = dcIngresos.vConcepto,
                });
                context.SaveChanges();
            }
        }

        public DCIngresos obtenerUltimoIngreso()
        {
            DCIngresos DCIngresos = new DCIngresos();
            using (var context = new MBEntities2())
            {
                var Ingresos = (from INGRESOS in context.INGRESOS
                                   orderby INGRESOS.iIdIngreso
                                   descending
                                   select INGRESOS).FirstOrDefault();
                DCIngresos.iIdIngresos = Ingresos.iIdIngreso;
                DCIngresos.dMonto = Ingresos.dMonto;
                DCIngresos.dFecha = Ingresos.dFecha;
                DCIngresos.vConcepto = Ingresos.vConcepto;
                DCIngresos.iIdTipoCambio = Ingresos.iIdTipoCambio;
            }
            return DCIngresos;
        }
    }
}