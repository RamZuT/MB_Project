using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;
using MB.WCF.Logica.Acciones;

namespace MB.WCF.Logica.Especificaciones
{
    public class EspecificacionHisTipoCambio
    {
        /// <summary>
        /// Función para llevar un registro historico de los tipos de cambio con cada inrgeso otra moneda
        /// </summary>
        /// <param name="dcTipoCambio">Modelo Tipo de cambio</param>
        public bool registroTipoCambio(DCHisTipoCambio dcTipoCambio) => new AccionTipoCambio().registroTipoCambio(dcTipoCambio);
        
        /// <summary>
        /// Función que retorna el ID del último tipo de cambio registrado en base de datos
        /// </summary>
        /// <returns>variable int con último cambio registrado</returns>
        public int obtenerUltimoIdTipoCambio() => new AccionTipoCambio().obtenerUltimoIdTipoCambio();

        /// <summary>
        /// Eliminar registros de tipo de cambio por medio del identificador
        /// </summary>
        /// <param name="idTipoCambio"></param>
        /// <returns></returns>
        public bool eliminarTipoCambioPorId(int idTipoCambio) => new AccionTipoCambio().eliminarTipoCambioPorId(idTipoCambio);
    }
}