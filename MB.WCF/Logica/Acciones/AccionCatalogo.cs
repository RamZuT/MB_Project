using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Accion
{
    public class AccionCatalogo
    {
        public List<DCCatalogo> ObtenerCatalogo()
        {
            List<DCCatalogo> listCatalogo = new List<DCCatalogo>();
            using (var context = new MBEntities())
            {
                var list = from CATALOGO in context.CATALOGO select CATALOGO;
                foreach (var _catalogo in list)
                {
                    DCCatalogo DCCatalogo = new DCCatalogo();
                    DCCatalogo.iIdCatalogo = _catalogo.iIdCatalogo;
                    DCCatalogo.vDetalle = _catalogo.vDetalle;
                    listCatalogo.Add(DCCatalogo);
                }
            }
            return listCatalogo;
        }
    }
}