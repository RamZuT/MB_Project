using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;
using MB.WCF.Logica.Accion;

namespace MB.WCF.Logica.Especificaciones
{
    public class EspecificacionCategorias
    {
        /// <summary>
        /// Función que obtiene la lista completa de categorías
        /// </summary>
        /// <returns>Retorna la lista de categorías</returns>
        public List<DCCategorias> ObtenerCategorias() => new AccionCategorias().ObtenerCategorias();
    }
}