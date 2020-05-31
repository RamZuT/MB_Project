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
        ServicioMonedas.ServicioMonedasClient urServMoneda = new ServicioMonedas.ServicioMonedasClient();
        ServicioIngresos.ServicioIngresosClient urServIngreso = new ServicioIngresos.ServicioIngresosClient();
        ServicioHistorialCapital.ServicioHistorialCapitalClient urServIngreCapital= new ServicioHistorialCapital.ServicioHistorialCapitalClient();
        // GET: Ingresos
        public ActionResult crearIngresos()
        {
            //Crea la lista de monedas y las muestra en el dropdown de la vista
            List<SelectListItem> Monedas = new List<SelectListItem>();
            var listaMonedas = new SelectList(urServMoneda.listaMonedas(), "iIdMoneda","vMoneda" );
            //Crea los montos de capital y los muestra en la vista
            var MontoActual = urServIngreCapital.capitalActual();
            MB.WEB.Models.IngresosRegistrar ingresoR = new IngresosRegistrar();
            ingresoR.dMontoCF = MontoActual.dMontoCF;
            ViewBag.Moneda = listaMonedas;
            return View(ingresoR);
        }

        [HttpPost]
        public ActionResult crearIngresos(IngresosRegistrar ingreso)
        {
            WCF.DataContract.DCIngresos dcingresoR = new WCF.DataContract.DCIngresos();
            WCF.DataContract.DCIngresos ultimoIngreso = new WCF.DataContract.DCIngresos();
            if (ModelState.IsValid)
            {
                dcingresoR.dMonto = ingreso.dMonto;
                dcingresoR.dFecha = ingreso.dFecha;
                dcingresoR.vConcepto = ingreso.vConcepto;
                dcingresoR.iMoneda = ingreso.iMoneda;
                urServIngreso.registroIngresos(dcingresoR);
                ultimoIngreso = urServIngreso.obtenerUltimoIngreso();
                //el true no va parametrizado por que es un ingreso por ahora permanece de esta forma.
                urServIngreCapital.registroHistCapital(ultimoIngreso.dFecha, true, ultimoIngreso.iIdIngresos, ultimoIngreso.dMonto);

            }
            return RedirectToAction("crearIngresos");
        }
    }
}