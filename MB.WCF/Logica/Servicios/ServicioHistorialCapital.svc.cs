using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MB.WCF.DataContract;
using MB.WCF.Logica.Especificaciones;

namespace MB.WCF.Logica.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioHistorialCapital" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioHistorialCapital.svc or ServicioHistorialCapital.svc.cs at the Solution Explorer and start debugging.
    public class ServicioHistorialCapital : IServicioHistorialCapital
    {
        /// <summary>
        /// Función que inserta cada cambio relacionado a la suma o resta del total del capital
        /// </summary>
        /// <param name="monto"></param>
        /// <param name="fechaCorte"></param>
        /// <param name="estado"></param>
        /// <returns>Retorna verdadero o falso al registrar correctamente</returns>
        public bool registroHistCapital(decimal monto, DateTime fechaCorte, bool estado) => 
            new EspecificacionHistCapital().registroHistCapital(monto, fechaCorte, estado);
        public DCHisCapitalFinanciero capitalActual() => new EspecificacionHistCapital().capitalActual();
        public DCHisCapitalFinanciero capitalInicial() => new EspecificacionHistCapital().capitalInicial();
        public decimal? calcularDiferenciaCapital() => new EspecificacionHistCapital().calcularDiferenciaCapital();
        public bool eliminarHisCapitalPorId(int idHistorial) => new EspecificacionHistCapital().eliminarHisCapitalPorId(idHistorial);
    }
}
