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
        /// Funcioón que inserta cada cambio relacionado a la suma del total del capital
        /// </summary>
        /// <param name="dcHisCapital"> Objeto que almacena lo relacionado al capital</param>
        public void registroHistCapital(DateTime fechaCorte, bool estado, int ingresoGasto, decimal monto) => new AccionHistorialCapital().registroHistCapital(fechaCorte, estado, ingresoGasto, monto);
    }
}