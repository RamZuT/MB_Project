using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MB.WEB.Models;

namespace MB.WEB.Controllers
{
    public class CategoriaController : Controller
    {
        ServicioCategorias.ServicioCategoriasClient ur = new ServicioCategorias.ServicioCategoriasClient();
        // GET: Categoria
        public ActionResult Index()
        {
            List<Categorias> List = new List<Categorias>();
            var listaCategorias = ur.ObtenerCategorias();

            foreach (var item in listaCategorias)
            {
                Categorias _categoria = new Categorias();
                _categoria.idCategoria = item.iIdCategoria;
                _categoria.categoria = item.vDetalle;
                List.Add(_categoria);
            }

            return View(List);
        }
    }
}