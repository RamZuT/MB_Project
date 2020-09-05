using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Acciones
{
    public class AccionDetPresupuesto
    {
        public DCDetallePresupuesto obtenerDetPresPorFechaYCatalogo(DateTime fecha, int idCatalogo)
        {
            DCDetallePresupuesto detalle = new DCDetallePresupuesto();
            using (var context = new MBEntities())
            {
                var _detalle = (from prep in context.PRESUPUESTO
                               join union in context.T_UNION_DETALLE_PRESUPUESTO on prep.iIdPresupuesto equals union.iIdPresupuesto
                               join det in context.DETALLE_PRESUPUESTO on new { union.iIdDetalle } equals new { det.iIdDetalle }

                               where fecha <= prep.dFechaFinal && fecha >= prep.dFechaInicio
                                     && idCatalogo == det.iIdCatalogo
                               select new { det.iIdCatalogo, det.iIdDetalle, det.dMonto }).FirstOrDefault();

                detalle.iIdDetalle = _detalle.iIdDetalle;
                detalle.iIdCatalogo = _detalle.iIdCatalogo;
                detalle.dMonto = _detalle.dMonto;     
            }
            return detalle;
        }
    }
}