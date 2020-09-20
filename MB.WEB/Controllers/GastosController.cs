using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using MB.WEB.Models;
namespace MB.WEB.Controllers
{
    public class GastosController : Controller
    {
        Utilidades.CrearObjetos crearObjetos = new Utilidades.CrearObjetos();
        ServicioCatalogo.ServicioCatalogoClient urServCatalogo = new ServicioCatalogo.ServicioCatalogoClient();
        ServicioMonedas.ServicioMonedasClient urServMonedas = new ServicioMonedas.ServicioMonedasClient();
        ServicioFormaPago.ServicioFormaPagoClient urServFormaPago = new ServicioFormaPago.ServicioFormaPagoClient();
        ServicioGastos.ServicioGastosClient urServGastos = new ServicioGastos.ServicioGastosClient();

        // GET: Gastos
        public ActionResult crearGastos()
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

        [HttpPost]
        public ActionResult crearGastos(Gastos nuevoGasto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (nuevoGasto.iIdMoneda == 1)
                    {
                        urServGastos.registroGasto(
                            crearObjetos.crearGasto(nuevoGasto.iIdCatalogo, nuevoGasto.dMonto, nuevoGasto.dFecha, nuevoGasto.vDetalle, nuevoGasto.iIdFormaPago),
                            crearObjetos.crearTipoCambioParcial(nuevoGasto.iIdMoneda, nuevoGasto.tipoCambio, nuevoGasto.dFecha)
                            );
                    }
                    else
                    {
                        urServGastos.registroGasto(
                            crearObjetos.crearGasto(nuevoGasto.iIdCatalogo, nuevoGasto.dMonto, nuevoGasto.dFecha, nuevoGasto.vDetalle, nuevoGasto.iIdFormaPago),
                            crearObjetos.crearTipoCambioParcial(nuevoGasto.iIdMoneda, nuevoGasto.tipoCambio, nuevoGasto.dFecha)
                            );
                    }
                }
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return RedirectToAction("crearGastos");
            }
            catch
            {
                return RedirectToAction("crearGastos");
            }
        }
    }
}