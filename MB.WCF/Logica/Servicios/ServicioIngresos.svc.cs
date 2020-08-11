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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioIngresos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioIngresos.svc or ServicioIngresos.svc.cs at the Solution Explorer and start debugging.
    public class ServicioIngresos : IServicioIngresos
    {
        public bool registroIngresos(DCIngresos dcIngersos) => new EspecificacionIngresos().registroIngresos(dcIngersos);
        public DCIngresos obtenerUltimoIngreso() => new EspecificacionIngresos().obtenerUltimoIngreso();
        public bool eliminarIngresoPorId(int idIngreso) => new EspecificacionIngresos().eliminarIngresoPorId(idIngreso);
        public bool registroUnionIngreso(int ingreso, int capital) => new EspecificacionIngresos().registroUnionIngreso(ingreso, capital);
    }
}
