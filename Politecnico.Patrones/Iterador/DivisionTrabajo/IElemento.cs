using System.Collections.Generic;

namespace Politecnico.Patrones.Iterador.DivisionTrabajo {
    public interface IElemento {
        string Nombre { get; set; }
        IEnumerator<IElemento> GetEnumerator();
        string TraerResumen();
        decimal TraerPorcentajeCompletado();
    }
}
