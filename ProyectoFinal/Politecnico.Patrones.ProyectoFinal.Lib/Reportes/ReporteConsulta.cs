using Politecnico.Patrones.ProyectoFinal.Contratos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Reportes {
    public abstract class ReporteConsulta : IReporteConsulta {
        public string Vista { get; set; }
        public virtual object Objeto { get; set; }
    }
}