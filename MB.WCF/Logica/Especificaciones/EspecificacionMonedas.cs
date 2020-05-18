using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;
using MB.WCF.Logica.Acciones;

namespace MB.WCF.Logica.Especificaciones
{
    public class EspecificacionMonedas
    {
        /// <summary>
        /// Función que obtiene las monedas almacenadas
        /// </summary>
        /// <returns>Retorna la lista de monedas</returns>
        public IEnumerable<DCMoneda> listaMonedas() => new AccionMonedas().listaMonedas();
    }
}