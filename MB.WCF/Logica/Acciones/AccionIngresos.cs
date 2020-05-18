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
    }
}