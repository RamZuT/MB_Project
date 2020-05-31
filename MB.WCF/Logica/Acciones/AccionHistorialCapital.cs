using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.WCF.DataContract;

namespace MB.WCF.Logica.Acciones
{
    public class AccionHistorialCapital
    {
        public void registroHistCapital(DateTime fechaCorte, bool estado, int ingresoGasto, decimal monto)
        {
            HIS_CAPITAL_FINANCIERO capitalActual = new HIS_CAPITAL_FINANCIERO();
            using (var context = new MBEntities())
            {
                if (estado == true)
                     {
                    capitalActual.dMontoCF = this.capitalActual().dMontoCF + monto;
                    capitalActual.dFechaDeCorte = fechaCorte;
                    capitalActual.bEstado = estado;
                    capitalActual.iIdIngreso = ingresoGasto;
                    capitalActual.iIdGastos = ' ';
                    context.HIS_CAPITAL_FINANCIERO.Add(capitalActual);
                    context.SaveChanges();
                }
                else
                {
                    capitalActual.dMontoCF = this.capitalActual().dMontoCF - monto;
                    capitalActual.dFechaDeCorte = fechaCorte;
                    capitalActual.bEstado = estado;
                    capitalActual.iIdIngreso = ingresoGasto;
                    capitalActual.iIdGastos = ' ';
                    context.HIS_CAPITAL_FINANCIERO.Add(capitalActual);
                    context.SaveChanges();
                }   
            }
        }

        public DCHisCapitalFinanciero capitalActual()
        {
            DCHisCapitalFinanciero DCCapitalActual = new DCHisCapitalFinanciero();
            using (var context = new MBEntities())
            {
                var CapitalActual = (from HIS_CAPITAL_FINANCIERO in context.HIS_CAPITAL_FINANCIERO orderby HIS_CAPITAL_FINANCIERO.iIdCapitalF
                                   descending select HIS_CAPITAL_FINANCIERO).FirstOrDefault();
                DCCapitalActual.iIdCapitalF = CapitalActual.iIdCapitalF;
                DCCapitalActual.dMontoCF = CapitalActual.dMontoCF;
                DCCapitalActual.dFechaDeCorte = CapitalActual.dFechaDeCorte;
                DCCapitalActual.bEstado = CapitalActual.bEstado;
                DCCapitalActual.iIdIngreso = CapitalActual.iIdIngreso;
                DCCapitalActual.iIdGastos = CapitalActual.iIdGastos;
            }
            return DCCapitalActual;
        }

        public DCHisCapitalFinanciero capitalInicial()
        {
            return null;
        }

        public decimal calcularDiferenciaCapital()
        {
            decimal diferencia = capitalInicial().dMontoCF - capitalActual().dMontoCF;
            return diferencia;
        }
    }
}