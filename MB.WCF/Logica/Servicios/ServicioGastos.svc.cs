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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioGastos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioGastos.svc or ServicioGastos.svc.cs at the Solution Explorer and start debugging.
    public class ServicioGastos : IServicioGastos
    {
        public bool guardarGasto(DCGastos gastos) => new EspecificacionGastos().guardarGasto(gastos);

        public DCGastos obtenerUltimoGasto() => new EspecificacionGastos().obtenerUltimoGasto();

        public bool guardarUnionDetalleGasto(int presupuesto, int detalle) => new EspecificacionGastos().guardarUnionDetalleGasto(presupuesto, detalle);

        public bool registroUnionGasto(int idGasto, int idCapital) => new EspecificacionGastos().registroUnionGasto(idGasto, idCapital);

    }
}
