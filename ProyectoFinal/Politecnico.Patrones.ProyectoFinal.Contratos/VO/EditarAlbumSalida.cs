using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.VO {
    public class EditarAlbumSalida : SalidaBase {
        public Album Album { get; set; }
        public EditarAlbumSalida(Resultados resultado)
            : base(resultado)
        {
        }
        public EditarAlbumSalida() {
        }
    }
}