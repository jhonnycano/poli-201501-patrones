using System;
using System.Collections.Generic;

namespace Politecnico.Patrones.Iterador.DivisionTrabajo
{
    public class GrupoTarea : IElemento
    {
        public string Nombre { get; set; }
        public decimal PorcentajeCompletado
        {
            get { return TraerPorcentajeCompletado(); }
            set { throw new ApplicationException("No usar setter en grupo"); }
        }
        public IList<IElemento> Elementos { get; set; }

        public GrupoTarea()
        {
            Elementos = new List<IElemento>();
        }

        public IEnumerator<IElemento> GetEnumerator()
        {
            yield return this;
            foreach (IElemento elemento in Elementos)
            {
                yield return elemento;
            }
        }
        public string TraerResumen()
        {
            /*
            var en = GetEnumerator();
            while (en.MoveNext())
            {
                
            }
             * */
            return "Grupo=>" + Nombre + ": " + TraerPorcentajeCompletado();
        }
        public decimal TraerPorcentajeCompletado()
        {
            decimal acum = 0m;
            var totalElementos = Elementos.Count;
            foreach (IElemento elemento in Elementos)
            {
                acum += (elemento.TraerPorcentajeCompletado() / totalElementos);
            }
            return acum;
        }
    }
}