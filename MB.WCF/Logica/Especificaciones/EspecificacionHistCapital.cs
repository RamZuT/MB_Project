using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;
using MB.WCF.Logica.Acciones;

namespace MB.WCF.Logica.Especificaciones
{
    public class EspecificacionHistCapital
    {
        /// <summary>
        /// Función que inserta cada cambio relacionado a la suma del total del capital
        /// </summary>
        /// <param name="dcHisCapital"> Objeto que almacena lo relacionado al capital</param>
        public void registroHistCapital(DateTime fechaCorte, bool estado, int ingresoGasto, decimal monto) => 
            new AccionHistorialCapital().registroHistCapital(fechaCorte, estado, ingresoGasto, monto);
        /// <summary>
        /// Función que retorna el capital actual del historial de capitales
        /// </summary>
        /// <returns>Objeto Historial Capital Financiero</returns>
        public DCHisCapitalFinanciero capitalActual() => new AccionHistorialCapital().capitalActual();
    }
}