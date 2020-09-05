using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;
using MB.WCF.Logica.Acciones;

namespace MB.WCF.Logica.Especificaciones
{
    public class EspecificacionDetPresupuesto
    {
        /// <summary>
        /// Retorna el detalle de un presupuesto para una categoría en un rango de fechas
        /// </summary>
        /// <param name="fecha">Fecha del movimiento</param>
        /// <param name="idCatalogo">ID de la catálogo a buscar</param>
        /// <returns>Retorna un registro de detalle según la fecha del movimiento y el id del catálogo</returns>
        public DCDetallePresupuesto obtenerDetPresPorFechaYCatalogo(DateTime fecha, int idCatalogo) => new AccionDetPresupuesto().obtenerDetPresPorFechaYCatalogo(fecha, idCatalogo);
    }
}