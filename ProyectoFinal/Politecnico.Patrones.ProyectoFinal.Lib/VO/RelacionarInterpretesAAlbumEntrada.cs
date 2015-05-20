using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Lib.VO {
    public class RelacionarInterpretesAAlbumEntrada {
        public enum Acciones { NoDefinido, Agregar, Eliminar }

        public int AlbumId { get; set; }
        public IList<int> Interpretes { get; set; }
        public Acciones Accion { get; set; }
    }
}