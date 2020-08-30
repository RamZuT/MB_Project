using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MB.WEB.Controllers
{
    public class GastosController : Controller
    {
        ServicioCatalogo.ServicioCatalogoClient urServCatalogo = new ServicioCatalogo.ServicioCatalogoClient();
        ServicioMonedas.ServicioMonedasClient urServMonedas = new ServicioMonedas.ServicioMonedasClient();
        ServicioFormaPago.ServicioFormaPagoClient urServFormaPago = new ServicioFormaPago.ServicioFormaPagoClient();

        // GET: Gastos
        public ActionResult Gastos()
        {
            //Crear las listas para dropdownList
            List<SelectListItem> Catalogos = new List<SelectListItem>();
            var listaCatalogos = new SelectList(urServCatalogo.ObtenerCatalogo(), "iIdCatalogo", "vDetalle");
            List<SelectListItem> Monedas = new List<SelectListItem>();
            var listaMonedas = new SelectList(urServMonedas.listaMonedas(), "iIdMoneda", "vMoneda");
            List<SelectListItem> FormaPago = new List<SelectListItem>();
            var listaFormaPago = new SelectList(urServFormaPago.obtenerListaFormaPago(), "iIdFormaPago", "vDetalleFP");

            ViewBag.Catalogo = listaCatalogos;
            ViewBag.Moneda = listaMonedas;
            ViewBag.FormaPago = listaFormaPago;

            return View();
        }

        // GET: Gastos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Gastos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gastos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gastos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Gastos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gastos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Gastos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
