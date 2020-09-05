using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MB.WCF.DataContract;


namespace MB.WCF.Logica.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioGastos" in both code and config file together.
    [ServiceContract]
    public interface IServicioGastos
    {
        [OperationContract]
        bool guardarGasto(DCGastos gastos);

        [OperationContract]
        DCGastos obtenerUltimoGasto();

        [OperationContract]
        bool guardarUnionDetalleGasto(int presupuesto, int detalle);
    }
}
