using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WCF.Logica.Acciones
{
    public class AccionPagos
    {
        public bool actualizarPago(int idCatalogo, DateTime fecha)
        {
            bool resultado = false;
            using (var context = new MBEntities())
            {
                var pago = (from PAGOS in context.PAGOS
                            where PAGOS.iIdCatalogo == idCatalogo
                            orderby PAGOS.dFechaVencePago descending
                            select PAGOS).FirstOrDefault();
                pago.bEstado = true;
                context.Entry(pago).State = System.Data.Entity.EntityState.Modified;
                resultado = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
            }
            return resultado;
        }
    }
}