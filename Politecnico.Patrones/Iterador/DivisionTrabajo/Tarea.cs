using System.Collections.Generic;

namespace Politecnico.Patrones.Iterador.DivisionTrabajo
{
    public class Tarea : IElemento
    {
        public string Nombre { get; set; }
        public int PorcentajeCompletado { get; set; }

        public void Agregar(IElemento elemento)
        {
        }
        public void Quitar(IElemento elemento)
        {
        }
        public string TraerResumen()
        {
            return Nombre + ": " + TraerPorcentajeCompletado();
        }
        public int TraerPorcentajeCompletado()
        {
            return PorcentajeCompletado;
        }
        public IEnumerator<IElemento> GetEnumerator()
        {
            yield return this;
        }
    }
}