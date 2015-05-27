using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Lib.Recursos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Reportes {
    internal class ReporteDetalleInterprete : ReporteBase {
        private IDictionary<string, object> _parametros;
        public ReporteDetalleInterprete(IGestorPersistencia gestorPersistencia) : base(gestorPersistencia) {
        }
        public override string Validar(IDictionary<string, object> parametros) {
            string result = ValidarParametrosNoNull(parametros);
            if (string.IsNullOrEmpty(result)) return result;

            if (!parametros.ContainsKey("Interprete")) return Cadenas.rpt_val_no_interprete;

            _parametros = parametros;
            return "";
        }
        public override IReporteConsulta Consultar() {
            var interpreteId = (int) _parametros["interprete"];
            var interprete = _gestorPersistencia.TraerInterprete(interpreteId);
            var albumes = _gestorPersistencia.TraerAlbumesInterprete(interpreteId);
            var canciones = _gestorPersistencia.TraerCancionesInterprete(interpreteId);
            return null;
        }
    }
}