using MB.WCF.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WCF.Logica.Acciones
{
    public class AccionPresupuestos
    {
        public DCPresupuesto ObtenerPresupuestoPorFecha(DateTime fecha)
        {
            DCPresupuesto presupuesto = new DCPresupuesto();
            using (var context = new MBEntities())
            {
                var _presupuesto = (from PRESUPUESTO in context.PRESUPUESTO
                                    where fecha <= PRESUPUESTO.dFechaFinal && fecha >= PRESUPUESTO.dFechaInicio
                                    select PRESUPUESTO).FirstOrDefault();
                presupuesto.iIdPresupuesto = _presupuesto.iIdPresupuesto;
                presupuesto.dFechaInicio = Convert.ToDateTime(_presupuesto.dFechaInicio);
                presupuesto.dFechaFinal = Convert.ToDateTime(_presupuesto.dFechaFinal);
                presupuesto.dMontoPresupuesto = _presupuesto.dMontoPresupuesto;
                presupuesto.dMontoReal = _presupuesto.dMontoReal;
            }
            return presupuesto;
        }

        public bool actualizaMontoRealPresupuesto(DateTime fecha, decimal? monto)
        {
            bool respuesta = false;
            using (var context = new MBEntities())
            {
                var prep = (from PRESUPUESTO in context.PRESUPUESTO
                            where fecha <= PRESUPUESTO.dFechaFinal && fecha >= PRESUPUESTO.dFechaInicio
                            select PRESUPUESTO).FirstOrDefault();
                prep.dMontoReal += monto;
                context.Entry(prep).State = System.Data.Entity.EntityState.Modified;
                respuesta = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
            }
            return respuesta;
        }
    }
}