using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioIngresos" in both code and config file together.
    [ServiceContract]
    public interface IServicioIngresos
    {
        [OperationContract]
        void registroIngresos(DCIngresos dcIngresos);
    }
}
