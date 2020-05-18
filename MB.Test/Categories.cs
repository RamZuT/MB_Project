using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MB.WCF.Logica.Service;
using System.Collections.Generic;
using MB.WCF.DataContract;

namespace MB.Test
{
    [TestClass]
    public class Categories
    {
        [TestMethod]
        public void getAllCategories()
        {
            var servicioCategorias = new WCF.Logica.Service.ServicioCategorias();
            List<DCCategorias> lista = new List<DCCategorias>();
            lista = servicioCategorias.ObtenerCategorias();

            Assert.IsNotNull(lista);

        }
    }
}
