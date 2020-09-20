using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Acciones
{
    public class AccionGastos
    {
        Utilidades.CrearObjetosWFC crearObjetos = new Utilidades.CrearObjetosWFC();
        Utilidades.Utilitarios utilitarios = new Utilidades.Utilitarios();

        public bool registroGasto(DCGastos nuevoGasto, DCHisTipoCambio tipoCambioParcial)
        {
            bool resultado = false;
            using (var context = new MBEntities())
            {
                using (var contextTransaccion = context.Database.BeginTransaction())
                {
                    try
                    {
                        //Registrar el gasto
                        context.GASTOS.Add(new GASTOS
                        {
                            iIdCatalogo = nuevoGasto.iIdCatalogo,
                            dMonto = nuevoGasto.dMonto,
                            dFecha = nuevoGasto.dFecha,
                            vDetalle = nuevoGasto.vDetalle,
                            iIdFormaPago = nuevoGasto.iIdFormaPago
                        });
                        context.SaveChanges();
                        //Obtener el gaste recién insertado
                        var ultimoGasto = (from GASTOS in context.GASTOS
                                           orderby GASTOS.iIdGastos
                                           descending
                                           select GASTOS).FirstOrDefault();
                        //Validar el tipo de moneda del gasto insertado
                        if (tipoCambioParcial.iIdMoneda == 1)
                        {
                            context.HIS_TIPO_CAMBIO.Add(new HIS_TIPO_CAMBIO
                            {
                                vMonto = tipoCambioParcial.vMonto,
                                dFecha = tipoCambioParcial.dFecha,
                                iIdMoneda = tipoCambioParcial.iIdMoneda,
                                iIdGasto = ultimoGasto.iIdGastos
                            });
                            context.SaveChanges();
                        }
                        //Registrar la unión del gasto con el detalle del presupuesto para lo cual se obtiene el detalle
                        //por la fecha y el catalogo del gasto registrado
                        var detPresupuesto = (from detPrep in context.PRESUPUESTO
                                              join union in context.T_UNION_DETALLE_PRESUPUESTO on detPrep.iIdPresupuesto equals union.iIdPresupuesto
                                              join det in context.DETALLE_PRESUPUESTO on new { union.iIdDetalle } equals new { det.iIdDetalle }
                                              where nuevoGasto.dFecha <= detPrep.dFechaFinal && nuevoGasto.dFecha >= detPrep.dFechaInicio
                                                    && nuevoGasto.iIdCatalogo == det.iIdDetalle
                                              select new { det.iIdCatalogo, det.iIdDetalle, det.dMonto}).FirstOrDefault();
                        //Guardar el registro en la tabla de unión detalle y gasto
                        context.T_UNION_GAS_DET_PRESUP.Add(new T_UNION_GAS_DET_PRESUP
                        {
                            iIdDetallePresupuesto = detPresupuesto.iIdDetalle,
                            iIdGasto = ultimoGasto.iIdGastos
                        });
                        context.SaveChanges();
                        //Actualizar el monto real del presupuesto actual
                        var prep = (from PRESUPUESTO in context.PRESUPUESTO
                                    where nuevoGasto.dFecha <= PRESUPUESTO.dFechaFinal && nuevoGasto.dFecha >= PRESUPUESTO.dFechaInicio
                                    select PRESUPUESTO).FirstOrDefault();
                        prep.dMontoReal += nuevoGasto.dMonto;
                        context.Entry(prep).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        //Para el registro del capital primero se obtiene el capital actual y en este caso se le resta 
                        //el monto del gasto registrado.
                        var capitalActual = (from HIS_CAPITAL_FINANCIERO in context.HIS_CAPITAL_FINANCIERO
                                             orderby HIS_CAPITAL_FINANCIERO.iIdCapitalF
                                             descending
                                             select HIS_CAPITAL_FINANCIERO).FirstOrDefault();
                        //Convertir el monto del gasto a colones
                        var monto = utilitarios.convertirDolarAColon(nuevoGasto.dMonto, tipoCambioParcial.vMonto);
                        //Guardar el nuevo historial menos el monto del gasto
                        context.HIS_CAPITAL_FINANCIERO.Add(new HIS_CAPITAL_FINANCIERO
                        {
                            dMontoCF = capitalActual.dMontoCF - monto,
                            dFechaDeCorte = nuevoGasto.dFecha,
                            bEstado = false //para los gastos
                        });
                        context.SaveChanges();

                        var IdUltimoCapital = (from HIS_CAPITAL_FINANCIERO in context.HIS_CAPITAL_FINANCIERO
                                               orderby HIS_CAPITAL_FINANCIERO.iIdCapitalF
                                               descending
                                               select HIS_CAPITAL_FINANCIERO.iIdCapitalF).FirstOrDefault();
                        //Regitrar la unión de capital y gastos
                        context.T_UNION_HIS_CF_GS.Add(new T_UNION_HIS_CF_GS
                        {
                            iIdGasto = ultimoGasto.iIdGastos,
                            iIdCapitalF = IdUltimoCapital
                        });
                        context.SaveChanges();
                        //Actualizar el control de pagos en caso de ser uno.
                        //Buscar si el pago existe
                        var pago = (from PAGOS in context.PAGOS
                                    where PAGOS.iIdCatalogo == nuevoGasto.iIdCatalogo
                                    orderby PAGOS.dFechaVencePago 
                                    descending
                                    select PAGOS).FirstOrDefault();
                        if (pago != null)
                        {
                            pago.bEstado = true;
                            context.Entry(pago).State = System.Data.Entity.EntityState.Modified;
                            context.SaveChanges();
                        }

                        contextTransaccion.Commit();
                    }
                    catch (Exception e)
                    {
                        var error = e;
                        
                        contextTransaccion.Rollback();
                        resultado = false;
                    }
                }
            }
            return resultado;
        }

        //VALIDAR SI ESTE METODO SE LLEGA A UTILIZAR DE LO CONTRARIO SE BORRA
        public void guardarGasto(DCGastos gastos)
        {
            using (var  context = new MBEntities())
            {
                context.GASTOS.Add(new GASTOS
                {
                    iIdCatalogo = gastos.iIdCatalogo,
                    dMonto = gastos.dMonto,
                    dFecha = gastos.dFecha,
                    vDetalle = gastos.vDetalle,
                    iIdFormaPago = gastos.iIdFormaPago
                });
                context.SaveChanges();
            }
        }

        public DCGastos obtenerUltimoGasto()
        {
            DCGastos dcGastos = new DCGastos();
            using (var context = new MBEntities())
            {
                var gastos = (from GASTOS in context.GASTOS
                              orderby GASTOS.iIdGastos
                              descending
                              select GASTOS).FirstOrDefault();
                dcGastos.iIdGastos = gastos.iIdGastos;
                dcGastos.iIdCatalogo = gastos.iIdCatalogo;
                dcGastos.dMonto = Convert.ToDecimal(gastos.dMonto);
                dcGastos.dFecha = Convert.ToDateTime(gastos.dFecha);
                dcGastos.iIdFormaPago = Convert.ToInt32(gastos.iIdFormaPago);
                dcGastos.vDetalle = gastos.vDetalle;
            }
            return dcGastos;
        }
        public bool guardarUnionDetalleGasto(int presupuesto, int detalle)
        {
            bool resultado = false;
            using (var context = new MBEntities())
            {
                context.T_UNION_DETALLE_PRESUPUESTO.Add(new T_UNION_DETALLE_PRESUPUESTO
                {
                    iIdDetalle = detalle,
                    iIdPresupuesto = presupuesto
                });
                resultado = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
            }

            return resultado;
        }

        public bool registroUnionGasto(int idGasto, int idCapital)
        {
            bool resultado = false;
            using (var context = new MBEntities())
            {
                context.T_UNION_HIS_CF_GS.Add(new T_UNION_HIS_CF_GS { iIdGasto = idGasto, iIdCapitalF = idCapital});
                resultado = (Convert.ToBoolean(context.SaveChanges()) == true ? true : false);
            }
            return resultado;
        }
    }
}