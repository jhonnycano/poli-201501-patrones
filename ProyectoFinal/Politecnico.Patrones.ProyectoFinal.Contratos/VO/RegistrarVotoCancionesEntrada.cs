using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.VO {
    public class RegistrarVotoCancionesEntrada {
        public enum Acciones { Asociar, Desasociar, }

        public int UsuarioId { get; set; }
        public IList<int> Canciones { get; set; }
        public Acciones Accion { get; set; }
    }
}