using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MB.WCF.DataContract;
using MB.WCF.Logica.Especificaciones;

namespace MB.WCF.Logica.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "CategoriesServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione CategoriesServices.svc o CategoriesServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioCategorias : IServicioCategorias
    {
        public List<DCCategorias> ObtenerCategorias() => new EspecificacionCategorias().ObtenerCategorias();

    }
}
