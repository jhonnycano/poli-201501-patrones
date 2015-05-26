using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Reportes {
    internal class ReporteListaCancionesAlbum : ReporteBase {
        public ReporteListaCancionesAlbum(IGestorPersistencia gestorPersistencia) : base(gestorPersistencia) {
        }
        public override string Validar(IDictionary<string, object> parametros) {
            return "";
        }
        public override IReporteConsulta Consultar() {
            return null;
        }
    }
}