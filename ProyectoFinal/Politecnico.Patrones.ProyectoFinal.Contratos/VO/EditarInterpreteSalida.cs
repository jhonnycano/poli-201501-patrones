using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.VO {
    public class EditarInterpreteSalida : SalidaBase {
        public Interprete Interprete { get; set; }
        public EditarInterpreteSalida(Resultados resultado) : base(resultado) {
        }
        public EditarInterpreteSalida() {
        }
    }
}