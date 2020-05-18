using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MB.WEB.Models;
using System.Globalization;

namespace MB.WEB.Controllers
{
    public class IngresosController : Controller
    {
        ServicioMonedas.ServicioMonedasClient ur = new ServicioMonedas.ServicioMonedasClient();
        ServicioIngresos.ServicioIngresosClient urServIngreso = new ServicioIngresos.ServicioIngresosClient();
        // GET: Ingresos
        public ActionResult crearIngresos()
        {
            List<SelectListItem> Monedas = new List<SelectListItem>();
            var listaMonedas = new SelectList(ur.listaMonedas(), "iIdMoneda","vMoneda" );
            ViewBag.Moneda = listaMonedas;
            return View();
        }

        [HttpPost]
        public ActionResult crearIngresos(IngresosRegistrar ingreso)
        {
            //Ingresos dcingresoR = new Ingresos();
            WCF.DataContract.DCIngresos dcingresoR = new WCF.DataContract.DCIngresos();
            if (ModelState.IsValid)
            {
                dcingresoR.dMonto = ingreso.dMonto;
                dcingresoR.dFecha = ingreso.dFecha;
                dcingresoR.vConcepto = ingreso.vConcepto;
                dcingresoR.iMoneda = ingreso.iMoneda;
                urServIngreso.registroIngresos(dcingresoR);
            }
            return RedirectToAction("crearIngresos");
        }
    }
}