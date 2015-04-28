using System.Collections.Generic;

namespace Politecnico.Patrones.Iterador.DivisionTrabajo {
    public interface IElemento {
        string Nombre { get; set; }
        double PorcentajeCompletado { get; set; }
        IEnumerator<IElemento> TraerEnumerador();
    }
}
