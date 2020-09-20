using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Acciones
{
    public class AccionIngresos
    {
        AccionTipoCambio HistipoCambio = new AccionTipoCambio();
        AccionHistorialCapital capital = new AccionHistorialCapital();

        Utilidades.CrearObjetosWFC crearObjetos = new Utilidades.CrearObjetosWFC();
        Utilidades.Utilitarios utilitarios = new Utilidades.Utilitarios();

        public bool registroIngresos(DCIngresos dcIngresos, DCHisTipoCambio tipoCambio)
        {
            bool resultado = false;
            using (var context = new MBEntities())
            {
                using (var contextTransaccion = context.Database.BeginTransaction()) 
                {
                    try
                    {
                        //Crear el registro de ingreso
                        context.INGRESOS.Add(new INGRESOS
                        {
                            dFecha = dcIngresos.dFecha,
                            dMonto = dcIngresos.dMonto,
                            vConcepto = dcIngresos.vConcepto,
                        });
                        context.SaveChanges();
                        
                        //Obtener el ingreso recién guardado
                        var Ingresos = (from INGRESOS in context.INGRESOS
                                        orderby INGRESOS.iIdIngreso
                                        descending
                                        select INGRESOS).FirstOrDefault();
                        
                        //Validar el tipo de moneda para guardar o no el historial de tipo de cambio
                        if (tipoCambio.iIdMoneda == 1)
                        {
                            context.HIS_TIPO_CAMBIO.Add(new HIS_TIPO_CAMBIO
                            {
                                vMonto = tipoCambio.vMonto,
                                dFecha = tipoCambio.dFecha,
                                iIdMoneda = tipoCambio.iIdMoneda,
                                iIdIngreso = Ingresos.iIdIngreso
                            });
                            context.SaveChanges();
                        }
                        //Para almacenar el Historial del capital primero se obtiene el ultimo registro de capital y este caso se le suma 
                        //el monto del ingreso
                        var capitalActual = (from HIS_CAPITAL_FINANCIERO in context.HIS_CAPITAL_FINANCIERO
                                             orderby HIS_CAPITAL_FINANCIERO.iIdCapitalF
                                             descending
                                             select HIS_CAPITAL_FINANCIERO).FirstOrDefault();
                        //Convertir la moneda a colones en caso de ser dólares
                        var monto = utilitarios.convertirDolarAColon(dcIngresos.dMonto, tipoCambio.vMonto);
                        //Guardar el nuevo Historial de Capital
                        capitalActual.dMontoCF = capitalActual.dMontoCF + monto;
                        capitalActual.dFechaDeCorte = dcIngresos.dFecha;
                        capitalActual.bEstado = true;//True para los ingresos
                        context.HIS_CAPITAL_FINANCIERO.Add(capitalActual);
                        context.SaveChanges();

                        var IdUltimoCapital = capitalActual.iIdCapitalF;
                        //Registrar la tabla de unión de Capital e ingresos
                        context.T_UNION_HIS_CF_IG.Add(new T_UNION_HIS_CF_IG
                        {
                            iIdIngreso = Ingresos.iIdIngreso,
                            iIdCapitalF = IdUltimoCapital
                        });
                        context.SaveChanges();

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
        //VALIDAR SI ESTE METODO NO SE UTILIZA SE PUEDE ELIMINAR
        public void guardarIngresos(DCIngresos dcIngresos, MBEntities context)
        {
            using (context)
            {
                context.INGRESOS.Add(new INGRESOS
                {
                    dFecha = dcIngresos.dFecha,
                    dMonto = dcIngresos.dMonto,
                    vConcepto = dcIngresos.vConcepto,
                });
                context.SaveChanges();
            }
        }
        public DCIngresos obtenerUltimoIngreso()
        {
            DCIngresos DCIngresos = new DCIngresos();
            using (var context = new MBEntities())
            {
                var Ingresos = (from INGRESOS in context.INGRESOS
                                   orderby INGRESOS.iIdIngreso
                                   descending
                                   select INGRESOS).FirstOrDefault();
                DCIngresos.iIdIngresos = Ingresos.iIdIngreso;
                DCIngresos.dMonto = Ingresos.dMonto;
                DCIngresos.dFecha = Ingresos.dFecha;
                DCIngresos.vConcepto = Ingresos.vConcepto;
            }
            return DCIngresos;
        }
        public void eliminarIngresoPorId(int idIngreso)
        {
            INGRESOS Ingresos = new INGRESOS();
            using (var context = new MBEntities())
            {
                var registro = (from _INGRESOS in context.INGRESOS
                                where _INGRESOS.iIdIngreso == idIngreso
                                select _INGRESOS).FirstOrDefault();
                if (registro != null)
                {
                    context.INGRESOS.Remove(registro);
                }
                context.SaveChanges();
            }
        }

        public void registroUnionIngreso(int ingreso, int capital)
        {
            using (var context = new MBEntities())
            {
                context.T_UNION_HIS_CF_IG.Add(new T_UNION_HIS_CF_IG
                {
                    iIdIngreso = ingreso,
                    iIdCapitalF = capital
                });
                context.SaveChanges();
            }
        }
    }
}