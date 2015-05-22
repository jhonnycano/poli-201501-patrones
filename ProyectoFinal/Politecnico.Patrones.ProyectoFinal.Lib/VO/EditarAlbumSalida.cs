using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Lib.VO {
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