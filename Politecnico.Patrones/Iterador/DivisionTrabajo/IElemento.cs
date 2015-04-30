using System.Collections.Generic;

namespace Politecnico.Patrones.Iterador.DivisionTrabajo {
    public interface IElemento {
        string Nombre { get; set; }
        void Agregar(IElemento elemento);
        void Quitar(IElemento elemento);
        string TraerResumen();
        int TraerPorcentajeCompletado();
        IEnumerator<IElemento> GetEnumerator();
    }
}
