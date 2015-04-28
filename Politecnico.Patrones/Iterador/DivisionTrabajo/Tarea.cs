using System.Collections.Generic;

namespace Politecnico.Patrones.Iterador.DivisionTrabajo {
    public class Tarea : IElemento {
        public string Nombre { get; set; }
        public double PorcentajeCompletado { get; set; }
        public IEnumerator<IElemento> TraerEnumerador() {
            
        }
    }
}