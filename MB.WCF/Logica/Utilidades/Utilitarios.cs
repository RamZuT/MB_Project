using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WCF.Logica.Utilidades
{
    public class Utilitarios
    {
        public DateTime fechaCorteAnnoActual(DateTime fechaHoy)
        {
            var anno = fechaHoy.Year;
            DateTime corteInicioAnno = new DateTime(anno,01,01);
            return corteInicioAnno;
        }
    }
}