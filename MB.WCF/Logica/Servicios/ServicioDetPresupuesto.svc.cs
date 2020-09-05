using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MB.WCF.DataContract;
using MB.WCF.Logica.Especificaciones;

namespace MB.WCF.Logica.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioDetPresupuesto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioDetPresupuesto.svc or ServicioDetPresupuesto.svc.cs at the Solution Explorer and start debugging.
    public class ServicioDetPresupuesto : IServicioDetPresupuesto
    {
        public DCDetallePresupuesto obtenerDetPresPorFechaYCatalogo(DateTime fecha, int idCatalogo) => new EspecificacionDetPresupuesto().obtenerDetPresPorFechaYCatalogo(fecha, idCatalogo);
    }
}
