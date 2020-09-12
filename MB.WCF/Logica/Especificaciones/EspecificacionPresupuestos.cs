using MB.WCF.DataContract;
using MB.WCF.Logica.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WCF.Logica.Especificaciones
{
    public class EspecificacionPresupuestos
    {
        /// <summary>
        /// Función para obtener el presupuesto creado en un rango de fechas
        /// </summary>
        /// <param name="fecha">Fecha que deberá estar entre un rango de fechas</param>
        /// <returns>Objeto presupuesto según la fecha suministrada</returns>
        public DCPresupuesto ObtenerPresupuestoPorFecha(DateTime fecha) => new AccionPresupuestos().ObtenerPresupuestoPorFecha(fecha);

        /// <summary>
        /// Función que actualiza el monto real del presupuesto
        /// </summary>
        /// <param name="fecha">Fecha del movimiento</param>
        /// <param name="monto">Monto del movimiento</param>
        /// <returns>Retorna true o false según el resultado de la función</returns>
        public bool actualizaMontoRealPresupuesto(DateTime fecha, decimal? monto) => new AccionPresupuestos().actualizaMontoRealPresupuesto(fecha, monto);
    }
}