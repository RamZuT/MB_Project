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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioHisTipoCambio" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioHisTipoCambio.svc or ServicioHisTipoCambio.svc.cs at the Solution Explorer and start debugging.
    public class ServicioHisTipoCambio : IServicioHisTipoCambio
    {
        public void registroTipoCambio(DCHisTipoCambio dcHisTipoCambio) => new EspecificacionHisTipoCambio().registroTipoCambio(dcHisTipoCambio);

    }
}
