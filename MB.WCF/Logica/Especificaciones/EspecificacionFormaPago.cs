using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;
using MB.WCF.Logica.Acciones;

namespace MB.WCF.Logica.Especificaciones
{
    public class EspecificacionFormaPago
    {
        /// <summary>
        /// Función que obtiene la lista completa de la forma de pago
        /// </summary>
        /// <returns>Retorna la lista de forma de pago</returns>
        public List<DCFormaPago> obtenerListaFormaPago() => new AccionFormaPago().obtenerListaFormaPago();
    }
}