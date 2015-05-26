using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Lib.Recursos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Reportes {
    public abstract class ReporteBase : IReporte {
        protected readonly IGestorPersistencia _gestorPersistencia;
        protected ReporteBase(IGestorPersistencia gestorPersistencia) {
            _gestorPersistencia = gestorPersistencia;
        }
        public abstract string Validar(IDictionary<string, object> parametros);
        public abstract IReporteConsulta Consultar();

        protected string ValidarParametrosNoNull(IDictionary<string, object> parametros) {
            return parametros == null ? Cadenas.rpt_val_no_parametros : "";
        }
        protected string ValidarFechas(IDictionary<string, object> parametros) {
            return !parametros.ContainsKey("FchInicio")
                ? Cadenas.rpt_val_no_fch_inicio
                : (!parametros.ContainsKey("FchFin")
                    ? Cadenas.rpt_val_no_fch_fin
                    : "");
        }
    }
}