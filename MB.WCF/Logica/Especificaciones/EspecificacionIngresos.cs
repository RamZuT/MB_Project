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
        /// <param name="dcIngresos">Tipo de objeto del modelo WCF que representa un ingreso</param>
        /// <returns>Verdadero o false si se almacena en Base de datos.</returns>
        public bool registroIngresos(DCIngresos dcIngresos, DCHisTipoCambio tipoCambio) => new AccionIngresos().registroIngresos(dcIngresos, tipoCambio);

        /// <summary>
        /// Función que obtiene el objeto del último ingreso registrado
        /// </summary>
        /// <param></param>
        /// <returns>Retorna un objeto de tipo DCIngreso</returns>
        public DCIngresos obtenerUltimoIngreso() => new AccionIngresos().obtenerUltimoIngreso();

        /// <summary>
        /// Función que elimina registros individuales de ingresos por medio del id
        /// </summary>
        /// <param name="idIngreso"></param>
        /// <returns> retorna verdadero o false de acuerdo al resultado del query</returns>
        public void eliminarIngresoPorId(int idIngreso) => new AccionIngresos().eliminarIngresoPorId(idIngreso);

        /// <summary>
        /// Función que almacena la unión de las tablas historial de ingresos e ingresos
        /// </summary>
        /// <returns>Retorna verdadero o falso al insert</returns>
        public void registroUnionIngreso(int ingreso, int capital) => new AccionIngresos().registroUnionIngreso(ingreso, capital);

    }
}