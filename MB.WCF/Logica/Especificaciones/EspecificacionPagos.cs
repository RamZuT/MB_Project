using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.Logica.Acciones;

namespace MB.WCF.Logica.Especificaciones
{
    public class EspecificacionPagos
    {
        /// <summary>
        /// Función que actualiza el estado de los pagos si existen
        /// </summary>
        /// <param name="idCatalogo">Identificador  del catálogo</param>
        /// <param name="fecha">Fecha del movimiento</param>
        /// <returns>Retorna un verdadero o falso según el resultado de la función</returns>
        public bool actualizarPago(int idCatalogo, DateTime fecha) => new AccionPagos().actualizarPago(idCatalogo, fecha);
    }
}