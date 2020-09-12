using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;
using MB.WCF.Logica.Acciones;

namespace MB.WCF.Logica.Especificaciones
{
    public class EspecificacionGastos
    {
        /// <summary>
        /// Almacena un gasto en la tabla Gastos
        /// </summary>
        /// <param name="gastos">Representa a un objeto de tipo DCGastos</param>
        /// <returns>Retorna un true o false según el resultado exitoso o fallido</returns>
        public bool guardarGasto(DCGastos gastos) => new AccionGastos().guardarGasto(gastos);

        /// <summary>
        /// Función que obtiene el último registro de gastos
        /// </summary>
        /// <returns>Retorna un objeto DCGastos</returns>
        public DCGastos obtenerUltimoGasto() => new AccionGastos().obtenerUltimoGasto();
        /// <summary>
        /// Función  para almacenar la unión de las tablas presupuesto y detalle de presupuesto
        /// </summary>
        /// <param name="union"></param>
        /// <returns>Retorna un verdadero o falso dependiendo del resultado</returns>
        public bool guardarUnionDetalleGasto(int presupuesto, int detalle) => new AccionGastos().guardarUnionDetalleGasto(presupuesto, detalle);

        public bool registroUnionGasto(int idGasto, int idCapital) => new AccionGastos().registroUnionGasto(idGasto, idCapital);
    }
}