using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.VO {
    public class RelacionarInterpretesACancionEntrada {
        public enum Acciones { NoDefinido, Agregar, Eliminar }

        public Acciones Accion { get; set; }
        public int CancionId { get; set; }
        public IList<int> Interpretes { get; set; }
    }
}