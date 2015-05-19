using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Lib.VO {
    public class IdentificarUsuarioSalida : SalidaBase {
        public IdentificarUsuarioSalida(Resultados resultado) : base(resultado) {
        }
        public IdentificarUsuarioSalida() {
        }
        public Usuario Usuario { get; set; }
    }
}