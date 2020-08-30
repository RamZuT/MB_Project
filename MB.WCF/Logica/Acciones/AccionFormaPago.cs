using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Acciones
{
    public class AccionFormaPago
    {
        public List<DCFormaPago> obtenerListaFormaPago()
        {
            List<DCFormaPago> listaFormaPago = new List<DCFormaPago>();
            using (var context = new MBEntities())
            {
                var list = from FORMA_PAGO in context.FORMA_PAGO select FORMA_PAGO;
                foreach (var _formaPago in list)
                {
                    DCFormaPago formaPago = new DCFormaPago();
                    formaPago.iIdFormaPago = _formaPago.iIdFormaPago;
                    formaPago.vDetalleFP = _formaPago.vDetalleFP;

                    listaFormaPago.Add(formaPago);
                }
                return listaFormaPago;
            }
        }
    }
}