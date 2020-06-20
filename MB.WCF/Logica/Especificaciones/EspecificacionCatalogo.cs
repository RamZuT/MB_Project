using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;
using MB.WCF.Logica.Accion;

namespace MB.WCF.Logica.Especificaciones
{
    public class EspecificacionCatalogo
    {
        /// <summary>
        /// Función que obtiene la lista completa de categorías
        /// </summary>
        /// <returns>Retorna la lista de categorías</returns>
        public List<DCCatalogo> ObtenerCatalogo() => new AccionCatalogo().ObtenerCatalogo();
    }
}