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
        Utilidades.Utilidades utilidades = new Utilidades.Utilidades();
        ServicioCatalogo.ServicioCatalogoClient urServCatalogo = new ServicioCatalogo.ServicioCatalogoClient();
        ServicioMonedas.ServicioMonedasClient urServMonedas = new ServicioMonedas.ServicioMonedasClient();
        ServicioFormaPago.ServicioFormaPagoClient urServFormaPago = new ServicioFormaPago.ServicioFormaPagoClient();
        ServicioHisTipoCambio.ServicioHisTipoCambioClient urSercHisTipoCambio = new ServicioHisTipoCambio.ServicioHisTipoCambioClient();
        ServicioHistorialCapital.ServicioHistorialCapitalClient urServHistCapital = new ServicioHistorialCapital.ServicioHistorialCapitalClient();
        ServicioGastos.ServicioGastosClient urServGastos = new ServicioGastos.ServicioGastosClient();
        ServicioDetPresupuesto.ServicioDetPresupuestoClient urServDetallePresupuesto = new ServicioDetPresupuesto.ServicioDetPresupuestoClient();

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
        [ValidateAntiForgeryToken]
        public ActionResult crearGastos(Gastos nuevoGasto)
        {
            try
            {
                var continua = false;
                if (ModelState.IsValid)
                {
                    if (nuevoGasto.iIdMoneda == 1)
                    {
                        continua = (urServGastos.guardarGasto(crearObjetos.crearGasto(nuevoGasto.iIdCatalogo, nuevoGasto.dMonto,
                            nuevoGasto.dFecha, nuevoGasto.vDetalle, nuevoGasto.iIdFormaPago)));
                        if (continua == true)
                        {
                            var ultimoGasto = urServGastos.obtenerUltimoGasto();
                            continua = (urSercHisTipoCambio.registroTipoCambio(crearObjetos.crearTipoCambio(nuevoGasto.iIdMoneda, nuevoGasto.tipoCambio,
                                nuevoGasto.dFecha, 0, ultimoGasto.iIdGastos)));
                            if (continua == true)
                            {
                                var detallePresupuesto = urServDetallePresupuesto.obtenerDetPresPorFechaYCatalogo(nuevoGasto.dFecha,
                                    nuevoGasto.iIdCatalogo);                            
                                continua = (urServGastos.guardarUnionDetalleGasto(ultimoGasto.iIdGastos,
                                    detallePresupuesto.iIdDetalle));
                                if (continua == true)
                                {
                                    var ultimoPresupuesto = urServPresupuesto.ObtenerPresupuestoPorFecha(nuevoGasto.dFecha);
                                    continua = (urServPresupuesto.actualizaMontoRealPresupuesto(ultimoPresupuesto.iIdPresupuesto, 
                                        utilidades.sumaMontoRealPresupuesto(ultimoPresupuesto.dMontoReal, nuevoGasto.dMonto))));
                                    if (continua == true)
                                    {
                                        urServHistCapital.actualizarCapitalPorGasto(ultimoGasto);
                                        //Afectar el control de gastos
                                        //Si no funciona debe eliminar la actualizacion del capital
                                        //Detalle de presupuesto
                                        //borrar historial de tipo de cambio
                                        //borrar ultimo gasto
                                    }
                                    else
                                    {
                                        //urServGastos.eliminarUnionDetalleGasto();
                                        //borrar historial de tipo de cambio
                                        //borrar ultimo gasto
                                    }

                                }
                                else
                                {
                                    //borrar historial de tipo de cambio
                                    //borrar ultimo gasto
                                }
                            }
                            else
                            {
                                //borrar ultimo gasto
                            }
                        }
                    }
                    else
                    {
                        //Primero guardar el gasto
                        //Segundo union del detalle y gasto
                        //Tercero Actualizar el monto en la tabla presupuesto
                        //Afectar el capital
                        //Afectar el control de gastos
                    }
                }
                return RedirectToAction("crearGastos");
            }
            catch
            {
                return RedirectToAction("crearGastos");
            }
        }
    }
}