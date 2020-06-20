using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MB.WEB.Models;

namespace MB.WEB.Controllers
{
    public class CatalogoController : Controller
    {
        ServicioCatalogo.ServicioCatalogoClient ur = new ServicioCatalogo.ServicioCatalogoClient();
        // GET: Catalogo
        public ActionResult Index()
        {
            List<Catalogo> List = new List<Catalogo>();
            var listaCatalogo = ur.ObtenerCatalogo();

            foreach (var item in listaCatalogo)
            {
                Catalogo _catalogo = new Catalogo();
                _catalogo.idCatalogo = item.iIdCatalogo;
                _catalogo.catalogo = item.vDetalle;
                List.Add(_catalogo);
            }

            return View(List);
        }
    }
}