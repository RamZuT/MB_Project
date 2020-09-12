using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioHistorialCapital" in both code and config file together.
    [ServiceContract]
    public interface IServicioHistorialCapital
    {
        /// <summary>
        /// Función que inserta cada cambio relacionado a la suma o resta del total del capital
        /// </summary>
        /// <param name="monto"></param>
        /// <param name="fechaCorte"></param>
        /// <param name="estado"></param>
        /// <returns>Retorna verdadero o falso al registrar correctamente</returns>
        [OperationContract]
        bool registroHistCapital(decimal monto, DateTime fechaCorte, bool estado);
        [OperationContract]
        DCHisCapitalFinanciero capitalActual();
        [OperationContract]
        DCHisCapitalFinanciero capitalInicial();
        [OperationContract]
        decimal? calcularDiferenciaCapital();
        [OperationContract]
        bool eliminarHisCapitalPorId(int idHistorial);
    }
}
