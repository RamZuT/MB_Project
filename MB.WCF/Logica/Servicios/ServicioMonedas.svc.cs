using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioMonedas" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioMonedas.svc o ServicioMonedas.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioMonedas : IServicioMonedas
    {
        public IEnumerable<DCMoneda> listaMonedas() => new Especificaciones.EspecificacionMonedas().listaMonedas();
    }
}
