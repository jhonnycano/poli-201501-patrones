namespace Politecnico.Patrones.ProyectoFinal.Contratos.VO {
    public class GenerarReporteSalida : SalidaBase {
        public IReporteConsulta Consulta { get; set; }
        public GenerarReporteSalida(Resultados resultado) : base(resultado) {}
        public GenerarReporteSalida() {}
    }
}