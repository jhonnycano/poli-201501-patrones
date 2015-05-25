using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.VO {
    public class IdentificarUsuarioSalida : SalidaBase {
        public IdentificarUsuarioSalida(Resultados resultado) : base(resultado) {
        }
        public IdentificarUsuarioSalida() {
        }
        public Usuario Usuario { get; set; }
    }
}