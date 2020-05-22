using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Acciones
{
    public class AccionHistorialCapital
    {
        public void registroHistCapital(DCHisCapitalFinanciero dcHisCapital)
        {
                    /*id se auto genera
                     * Monto se calcula
                     fecha de corte = fecha del movimiento viene desde la vista
                     Estato para identificar si es suma o resta viene desde vista
                     id de ingreso o gasto viene desde vista*/
        }

        public DCHisCapitalFinanciero capitalActual()
        {
            return null;
        }

        public DCHisCapitalFinanciero capitalInicial()
        {
            return null;
        }
    }
}