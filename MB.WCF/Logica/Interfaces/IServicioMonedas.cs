using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioMonedas" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioMonedas
    {
        [OperationContract]
        IEnumerable<DCMoneda> listaMonedas();
    }
}
