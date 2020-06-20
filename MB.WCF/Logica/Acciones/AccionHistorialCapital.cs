using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Acciones
{
    public class AccionHistorialCapital
    {
        Utilidades.Utilitarios fecha = new Utilidades.Utilitarios();


        public void registroHistCapital(DateTime fechaCorte, bool estado, int ingresoGasto, decimal monto)
        {
            HIS_CAPITAL_FINANCIERO capitalActual = new HIS_CAPITAL_FINANCIERO();
            using (var context = new MBEntities2())
            {
                if (estado == true)
                     {
                    capitalActual.dMontoCF = this.capitalActual().dMontoCF + monto;
                    capitalActual.dFechaDeCorte = fechaCorte;
                    capitalActual.bEstado = estado;
                    context.HIS_CAPITAL_FINANCIERO.Add(capitalActual);
                    context.SaveChanges();
                }
                else
                {
                    capitalActual.dMontoCF = this.capitalActual().dMontoCF - monto;
                    capitalActual.dFechaDeCorte = fechaCorte;
                    capitalActual.bEstado = estado;
                    context.HIS_CAPITAL_FINANCIERO.Add(capitalActual);
                    context.SaveChanges();
                }   
            }
        }

        public DCHisCapitalFinanciero capitalActual()
        {
            DCHisCapitalFinanciero DCCapitalActual = new DCHisCapitalFinanciero();
            using (var context = new MBEntities2())
            {
                var CapitalActual = (from HIS_CAPITAL_FINANCIERO in context.HIS_CAPITAL_FINANCIERO orderby HIS_CAPITAL_FINANCIERO.iIdCapitalF
                                   descending select HIS_CAPITAL_FINANCIERO).FirstOrDefault();
                if (CapitalActual!=null)
                {
                    DCCapitalActual.iIdCapitalF = CapitalActual.iIdCapitalF;
                    DCCapitalActual.dMontoCF = CapitalActual.dMontoCF;
                    DCCapitalActual.dFechaDeCorte = CapitalActual.dFechaDeCorte;
                    DCCapitalActual.bEstado = CapitalActual.bEstado;
                }
                else
                {
                    DCCapitalActual.dMontoCF = 0;
                }
            }
            return DCCapitalActual;
        }

        public DCHisCapitalFinanciero capitalInicial()
        {
            DCHisCapitalFinanciero DCCapitalInicial = new DCHisCapitalFinanciero();
            //Obtiene la fecha de inicio de año
            DateTime fechaInicioAnno = fecha.fechaCorteAnnoActual(DateTime.Today);
            //Obtener el capital por fecha de corte
            DCCapitalInicial = ObtieneCapitalPorFechaCorte(fechaInicioAnno);
            if (DCCapitalInicial != null)
            {
                return DCCapitalInicial;
            }
            else
            {
                //Busca el primer capital insertado
                DCCapitalInicial = ObtienePrimerCapital();
            }
            return DCCapitalInicial;
        }

        public decimal? calcularDiferenciaCapital()
        {
            decimal? diferencia = capitalInicial().dMontoCF - capitalActual().dMontoCF;
            return diferencia;
        }

        #region Métodos
        public DCHisCapitalFinanciero ObtieneCapitalPorFechaCorte(DateTime fechaCorte)
        {
            DCHisCapitalFinanciero DCCapitalInicialPorFecha = new DCHisCapitalFinanciero();
            using (var context = new MBEntities2())
            {
                var CapitalInicial = (from _HIS_CAPITAL_FINANCIERO in context.HIS_CAPITAL_FINANCIERO
                                      where _HIS_CAPITAL_FINANCIERO.dFechaDeCorte == fechaCorte
                                      select _HIS_CAPITAL_FINANCIERO).FirstOrDefault();
                if (CapitalInicial != null)
                {
                    DCCapitalInicialPorFecha.iIdCapitalF = CapitalInicial.iIdCapitalF;
                    DCCapitalInicialPorFecha.dMontoCF = CapitalInicial.dMontoCF;
                    DCCapitalInicialPorFecha.dFechaDeCorte = CapitalInicial.dFechaDeCorte;
                    DCCapitalInicialPorFecha.bEstado = CapitalInicial.bEstado;
                } else
                {
                    DCCapitalInicialPorFecha = null;
                }
            }
            return DCCapitalInicialPorFecha;
        }

        public DCHisCapitalFinanciero ObtienePrimerCapital()
        {
            DCHisCapitalFinanciero DCCapitalInicial = new DCHisCapitalFinanciero();
            using (var context = new MBEntities2())
            {
                var CapitalActual = (from HIS_CAPITAL_FINANCIERO in context.HIS_CAPITAL_FINANCIERO
                                     orderby HIS_CAPITAL_FINANCIERO.iIdCapitalF
                                     select HIS_CAPITAL_FINANCIERO).FirstOrDefault();
                if (CapitalActual != null)
                {
                    DCCapitalInicial.iIdCapitalF = CapitalActual.iIdCapitalF;
                    DCCapitalInicial.dMontoCF = CapitalActual.dMontoCF;
                    DCCapitalInicial.dFechaDeCorte = CapitalActual.dFechaDeCorte;
                    DCCapitalInicial.bEstado = CapitalActual.bEstado;
                }
                else
                {
                    DCCapitalInicial.dMontoCF = 0;
                }
            }
            return DCCapitalInicial;
        }
        #endregion
    }
}