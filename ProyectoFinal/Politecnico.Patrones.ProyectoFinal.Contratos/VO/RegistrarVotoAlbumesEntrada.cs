using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.VO {
    public class RegistrarVotoAlbumesEntrada {
        public enum Acciones { Asociar, Desasociar, }

        public int UsuarioId { get; set; }
        public IList<int> Albumes { get; set; }
        public Acciones Accion { get; set; }
    }
}