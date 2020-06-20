using System;
using System.Collections.Generic;
using System.Linq;
using MB.WCF.DataContract;
using System.Web;

namespace MB.WCF.Logica.Acciones
{
    public class AccionMonedas
    {
        public IEnumerable<DCMoneda> listaMonedas()
        {
            List<DCMoneda> listMonedas = new List<DCMoneda>();
            using (var context = new MBEntities())
            {
                var list = from MONEDA in context.MONEDA select MONEDA;
                if (list!=null)
                {
                    foreach (var _monedas in list)
                    {
                        DCMoneda dcmodena = new DCMoneda();
                        dcmodena.iIdMoneda = _monedas.iIdMoneda;
                        dcmodena.vCodMoneda = _monedas.vCodMoneda;
                        dcmodena.vMoneda = _monedas.vMoneda;
                        listMonedas.Add(dcmodena);
                    }
                }
            }
            return listMonedas;
        }
    }
}