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
        Utilidades.CrearObjetos crearObjetos = new Utilidades.CrearObjetos();
        ServicioMonedas.ServicioMonedasClient urServMoneda = new ServicioMonedas.ServicioMonedasClient();
        ServicioIngresos.ServicioIngresosClient urServIngreso = new ServicioIngresos.ServicioIngresosClient();
        ServicioHistorialCapital.ServicioHistorialCapitalClient urServHistCapital= new ServicioHistorialCapital.ServicioHistorialCapitalClient();
        ServicioHisTipoCambio.ServicioHisTipoCambioClient urSercHisTipoCambio = new ServicioHisTipoCambio.ServicioHisTipoCambioClient();
        Utilidades.Utilidades utilitarios = new Utilidades.Utilidades();
        // GET: Ingresos
        public ActionResult crearIngresos()
        {
            //Crea la lista de monedas y las muestra en el dropdown de la vista
            List<SelectListItem> Monedas = new List<SelectListItem>();
            var listaMonedas = new SelectList(urServMoneda.listaMonedas(), "iIdMoneda", "vMoneda" );
            //Crea los montos de capital y los muestra en la vista
            var MontoActual = urServHistCapital.capitalActual();
            var MontoInicial = urServHistCapital.capitalInicial();
            var Diferencia = urServHistCapital.calcularDiferenciaCapital();

            MB.WEB.Models.IngresosRegistrar ingresoR = new IngresosRegistrar();
            ingresoR.dMontoCF = MontoActual.dMontoCF;
            ingresoR.dMontoCF_Inicial = MontoInicial.dMontoCF;
            ingresoR.dMontoCF_dif = Diferencia;

           // ViewBag.Readonly = true;
            ViewBag.Moneda = listaMonedas;

            return View(ingresoR);
        }

        [HttpPost]
        public ActionResult crearIngresos(IngresosRegistrar ingreso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ingreso.iMoneda == 1)
                    {
                        urServIngreso.registroIngresos(
                            crearObjetos.crearIngreso(ingreso.dMonto, ingreso.dFecha, ingreso.vConcepto),
                            crearObjetos.crearTipoCambioParcial(ingreso.iMoneda, ingreso.tipoCambio, ingreso.dFecha)
                            );
                    }
                    else
                    {
                        urServIngreso.registroIngresos(
                            crearObjetos.crearIngreso(ingreso.dMonto, ingreso.dFecha, ingreso.vConcepto),
                            crearObjetos.crearTipoCambioParcial(ingreso.iMoneda, ingreso.tipoCambio, ingreso.dFecha)
                            );
                    }

                }
                return RedirectToAction("crearIngresos");
            }
            catch 
            {
                return View();
            }
        }
    }
}