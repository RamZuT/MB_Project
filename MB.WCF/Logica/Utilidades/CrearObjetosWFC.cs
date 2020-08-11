using MB.WCF.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB.WCF.Logica.Utilidades
{
    public class CrearObjetosWFC
    {
        DCUnion_HisCap_InGa unionIngreso = new DCUnion_HisCap_InGa();
        public DCUnion_HisCap_InGa crearObjetoIngreso(int ingreso, int capital)
        {
            if (!ingreso.Equals(null) || !capital.Equals(null))
            {
                unionIngreso.iIdIngreso = ingreso;
                unionIngreso.iIdCapitalF = capital;
            }
            return unionIngreso;
        }
    }
}