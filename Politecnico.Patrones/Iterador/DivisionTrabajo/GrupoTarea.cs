using System;
using System.Collections.Generic;
using System.Text;

namespace Politecnico.Patrones.Iterador.DivisionTrabajo
{
    public class GrupoTarea : IElemento
    {
        public string Nombre { get; set; }
        public int PorcentajeCompletado
        {
            get { return TraerPorcentajeCompletado(); }
            set { throw new ApplicationException("No usar setter en grupo"); }
        }
        public IList<IElemento> Elementos { get; set; }

        public GrupoTarea()
        {
            Elementos = new List<IElemento>();
        }
        public void Agregar(IElemento elemento)
        {
            Elementos.Add(elemento);
        }
        public void Quitar(IElemento elemento)
        {
            Elementos.Remove(elemento);
        }
        public string TraerResumen()
        {
            var sb = new StringBuilder();
            var iterador = GetEnumerator();
            while (iterador.MoveNext())
            {
                sb.AppendLine(iterador.Current.TraerResumen());
            }

            return sb.ToString();
        }
        public int TraerPorcentajeCompletado()
        {
            int acum = 0;
            int totalElementos = Elementos.Count;
            foreach (IElemento elemento in Elementos)
            {
                acum += (elemento.TraerPorcentajeCompletado()/totalElementos);
            }
            return acum;
        }
        public IEnumerator<IElemento> GetEnumerator()
        {
            yield return this;
            foreach (IElemento elemento in Elementos)
            {
                var en = elemento.GetEnumerator();
                while (en.MoveNext()) yield return en.Current;
            }

        }
    }
}