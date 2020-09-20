using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MB.WCF.Logica.Especificaciones;

namespace MB.WCF.Logica.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioPagos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioPagos.svc or ServicioPagos.svc.cs at the Solution Explorer and start debugging.
    public class ServicioPagos : IServicioPagos
    {
        public bool actualizarPago(int idCatalogo, DateTime fecha, bool estado) => new EspecificacionPagos().actualizarPago(idCatalogo, fecha, estado);
    }
}
