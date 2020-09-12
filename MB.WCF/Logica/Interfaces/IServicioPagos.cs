using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MB.WCF.Logica.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioPagos" in both code and config file together.
    [ServiceContract]
    public interface IServicioPagos
    {
        [OperationContract]
        bool actualizarPago(int idCatalogo, DateTime fecha);
    }
}
