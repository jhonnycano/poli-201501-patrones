using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Reportes {
    internal class ReporteDetalleInterprete : ReporteBase {
        public ReporteDetalleInterprete(IGestorPersistencia gestorPersistencia) : base(gestorPersistencia) {
        }
        public override string Validar(IDictionary<string, object> parametros) {
            string result = ValidarParametrosNoNull(parametros);
            if (string.IsNullOrEmpty(result)) return result;

            if (!parametros.ContainsKey("Interprete")) return "Falta interprete";

            return "";
        }
        public override IReporteConsulta Consultar() {
            return null;
        }
    }
}