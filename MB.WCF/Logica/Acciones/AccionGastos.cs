using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Acciones
{
    public class AccionGastos
    {
        public bool guardarGasto(DCGastos gastos)
        {
            bool resultado = false;
            using (var  context = new MBEntities())
            {
                context.GASTOS.Add(new GASTOS
                {
                    iIdCatalogo = gastos.iIdCatalogo,
                    dMonto = gastos.dMonto,
                    dFecha = gastos.dFecha,
                    vDetalle = gastos.vDetalle,
                    iIdFormaPago = gastos.iIdFormaPago
                });
                resultado = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
            }

            return resultado;
        }

        public DCGastos obtenerUltimoGasto()
        {
            DCGastos dcGastos = new DCGastos();
            using (var context = new MBEntities())
            {
                var gastos = (from GASTOS in context.GASTOS
                              orderby GASTOS.iIdGastos
                              descending
                              select GASTOS).FirstOrDefault();
                dcGastos.iIdGastos = gastos.iIdGastos;
                dcGastos.iIdCatalogo = gastos.iIdCatalogo;
                dcGastos.dMonto = gastos.dMonto;
                dcGastos.dFecha = gastos.dFecha;
                dcGastos.iIdFormaPago = Convert.ToInt32(gastos.iIdFormaPago);
                dcGastos.vDetalle = gastos.vDetalle;
            }
            return dcGastos;
        }
        public bool guardarUnionDetalleGasto(int presupuesto, int detalle)
        {
            bool resultado = false;
            using (var context = new MBEntities())
            {
                context.T_UNION_DETALLE_PRESUPUESTO.Add(new T_UNION_DETALLE_PRESUPUESTO
                {
                    iIdDetalle = detalle,
                    iIdPresupuesto = presupuesto
                });
                resultado = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
            }

            return resultado;
        }
    }
}