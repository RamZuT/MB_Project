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
                WCF.DataContract.DCIngresos ultimoIngreso = new WCF.DataContract.DCIngresos();
                var continua = false;

                if (ModelState.IsValid)
                {
                    if (ingreso.iMoneda == 1)
                    {
                        continua = (urServIngreso.registroIngresos(crearObjetos.crearIngreso(ingreso.dMonto, ingreso.dFecha, ingreso.vConcepto)));
                        if (continua == true)
                        {
                            var _ultimoIngreso = urServIngreso.obtenerUltimoIngreso();
                            continua = (urSercHisTipoCambio.registroTipoCambio(crearObjetos.crearTipoCambio(ingreso.iMoneda, ingreso.tipoCambio, ingreso.dFecha, 
                                _ultimoIngreso.iIdIngresos, 0)));
                            if (continua == true)
                            {
                                var _idUltimoTipoCambio = urSercHisTipoCambio.obtenerUltimoIdTipoCambio();
                                continua = (urServHistCapital.registroHistCapital(utilitarios.convertirDolarAColon(_ultimoIngreso.dMonto, ingreso.tipoCambio),
                                    _ultimoIngreso.dFecha, true));
                                if (continua == true)
                                {
                                    var UltimoHistorial = urServHistCapital.capitalActual();
                                    continua = (urServIngreso.registroUnionIngreso(_ultimoIngreso.iIdIngresos, UltimoHistorial.iIdCapitalF));
                                    if (continua != true)
                                    {
                                        urServIngreso.eliminarIngresoPorId(ingreso.iIdIngresos);
                                        urSercHisTipoCambio.eliminarTipoCambioPorId(_ultimoIngreso.iIdIngresos);
                                        urServHistCapital.eliminarHisCapitalPorId(UltimoHistorial.iIdCapitalF);
                                    }
                                }
                                else
                                {
                                    urSercHisTipoCambio.eliminarTipoCambioPorId(_ultimoIngreso.iIdIngresos);
                                    urServIngreso.eliminarIngresoPorId(ingreso.iIdIngresos);
                                }
                            }
                            else
                            {
                                urServIngreso.eliminarIngresoPorId(ingreso.iIdIngresos);
                            }
                        }
                    }
                    else
                    {
                        continua = urServIngreso.registroIngresos(crearObjetos.crearIngreso(ingreso.dMonto, ingreso.dFecha, ingreso.vConcepto));
                        if (continua == true)
                        {
                            var _ultimoIngreso = urServIngreso.obtenerUltimoIngreso();
                            var UltimoHistorial = urServHistCapital.capitalActual();
                            continua = (urServHistCapital.registroHistCapital(_ultimoIngreso.dMonto, _ultimoIngreso.dFecha, true));
                            if (continua == true)
                            {
                                continua = (urServIngreso.registroUnionIngreso(_ultimoIngreso.iIdIngresos, UltimoHistorial.iIdCapitalF));
                                if (continua != true)
                                {
                                    urServIngreso.eliminarIngresoPorId(ingreso.iIdIngresos);
                                    urSercHisTipoCambio.eliminarTipoCambioPorId(_ultimoIngreso.iIdIngresos);
                                    urServHistCapital.eliminarHisCapitalPorId(UltimoHistorial.iIdCapitalF);
                                }
                            }
                        }
                        else
                        {
                            urServIngreso.eliminarIngresoPorId(ingreso.iIdIngresos);
                        }
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