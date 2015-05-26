using Politecnico.Patrones.ProyectoFinal.Contratos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Reportes {
    internal class ReporteConsulta : IReporteConsulta {
        public string Vista { get; set; }
        public object Objeto { get; set; }
    }
}