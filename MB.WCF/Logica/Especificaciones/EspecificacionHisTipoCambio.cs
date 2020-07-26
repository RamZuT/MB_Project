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
        public void registroTipoCambio(DCHisTipoCambio dcTipoCambio) => new AccionTipoCambio().registroTipoCambio(dcTipoCambio);
    }
}