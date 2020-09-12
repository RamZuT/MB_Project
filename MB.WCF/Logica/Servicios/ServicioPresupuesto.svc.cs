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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioPresupuesto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioPresupuesto.svc or ServicioPresupuesto.svc.cs at the Solution Explorer and start debugging.
    public class ServicioPresupuesto : IServicioPresupuesto
    {
        public DCPresupuesto ObtenerPresupuestoPorFecha(DateTime fecha) => new EspecificacionPresupuestos().ObtenerPresupuestoPorFecha(fecha);

        public bool actualizaMontoRealPresupuesto(DateTime fecha, decimal? monto) => new EspecificacionPresupuestos().actualizaMontoRealPresupuesto(fecha, monto);

    }
}
