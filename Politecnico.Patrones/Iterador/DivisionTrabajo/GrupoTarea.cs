using System.Collections.Generic;

namespace Politecnico.Patrones.Iterador.DivisionTrabajo {
    public class GrupoTarea : IElemento {
        public List<IElemento> Elementos { get; set; }
        public string Nombre { get; set; }
        public double PorcentajeCompletado { get; set; }
        public IEnumerator<IElemento> TraerEnumerador() {
            throw new System.NotImplementedException();
        }
    }
}
