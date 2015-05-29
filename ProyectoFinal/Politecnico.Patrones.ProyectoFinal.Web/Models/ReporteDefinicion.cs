using Politecnico.Patrones.ProyectoFinal.Contratos.VO;

namespace Politecnico.Patrones.ProyectoFinal.Web.Models {

    public class ReporteDefinicion {
        public string Etiqueta { get; set; }
        public TipoReporte Tipo { get; set; }
        public bool PermitirPdf { get; set; }
        public ReporteDefinicion() {
            PermitirPdf = true;
        }
    }
}