using MB.WCF.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WCF.Logica.Acciones
{
    public class AccionTipoCambio
    {
        public void registroTipoCambio(DCHisTipoCambio dcHisTipoCambio)
        {
            using (var context = new MBEntities())
            {
                context.HIS_TIPO_CAMBIO.Add(new HIS_TIPO_CAMBIO
                {
                    vMonto = dcHisTipoCambio.vMonto,
                    dFecha = dcHisTipoCambio.dFecha,
                    iIdMoneda = dcHisTipoCambio.iIdMoneda
                });
                context.SaveChanges();
            }
        }
    }
}