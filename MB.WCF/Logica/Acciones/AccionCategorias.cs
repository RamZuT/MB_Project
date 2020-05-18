using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Accion
{
    public class AccionCategorias
    {
        public List<DCCategorias> ObtenerCategorias()
        {
            List<DCCategorias> listCategoria = new List<DCCategorias>();
            using (var context = new MBEntities())
            {
                var list = from CATEGORIA in context.CATEGORIA select CATEGORIA;
                foreach (var _cateroria in list)
                {
                    DCCategorias DCCategoria = new DCCategorias();
                    DCCategoria.iIdCategoria = _cateroria.iIdCategoria;
                    DCCategoria.vDetalle = _cateroria.vDetalle;
                    listCategoria.Add(DCCategoria);
                }
            }
            return listCategoria;
        }
    }
}