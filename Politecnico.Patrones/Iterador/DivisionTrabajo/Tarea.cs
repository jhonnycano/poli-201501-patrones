using System.Collections.Generic;

namespace Politecnico.Patrones.Iterador.DivisionTrabajo
{
    public class Tarea : IElemento
    {
        public decimal PorcentajeCompletado { get; set; }
        public string Nombre { get; set; }
        public IEnumerator<IElemento> GetEnumerator()
        {
            yield return this;
        }
        public string TraerResumen()
        {
            return Nombre + ": " + TraerPorcentajeCompletado();
        }
        public decimal TraerPorcentajeCompletado()
        {
            return PorcentajeCompletado;
        }
    }
}