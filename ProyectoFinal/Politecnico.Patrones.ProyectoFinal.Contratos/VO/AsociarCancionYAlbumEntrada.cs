using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.VO {
    public class AsociarCancionYAlbumEntrada {
        public enum Acciones {
            Asociar,
            Desasociar
        }

        public int AlbumId { get; set; }
        public IList<int> Canciones { get; set; }
        public Acciones Accion { get; set; }
    }
}