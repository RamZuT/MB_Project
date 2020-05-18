using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;
using MB.WCF.Logica.Acciones;

namespace MB.WCF.Logica.Especificaciones
{
    public class EspecificacionIngresos
    {
        /// <summary>
        /// Función para registrar los ingresos de manera manual
        /// </summary>
        /// <param name="dcIngresos">Modelo ingresos</param>
        public void registroIngresos(DCIngresos dcIngresos) => new AccionIngresos().registroIngresos(dcIngresos);
    }
}