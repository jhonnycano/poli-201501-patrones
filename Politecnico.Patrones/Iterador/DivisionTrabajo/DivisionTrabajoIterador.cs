using System;
using System.Collections;
using System.Collections.Generic;

namespace Politecnico.Patrones.Iterador.DivisionTrabajo
{
    public class DivisionTrabajoIterador : IEnumerator<IElemento>
    {
        private enum EstadoIterador { NoIniciado, Iterando, Finalizado }
        private IElemento _actual;
        private readonly IElemento _inicial;
        private EstadoIterador _estado;
        public string Indentacion { get; set; }

        public DivisionTrabajoIterador(IElemento actual)
        {
            _inicial = actual;
            _actual = actual;
            Indentacion = "";
            _estado = EstadoIterador.NoIniciado;
        }

        public bool MoveNext()
        {
            if (_estado == EstadoIterador.Finalizado) throw new ApplicationException("Iterador no válido");
            if (_estado == EstadoIterador.NoIniciado)
            {
                _estado = EstadoIterador.Iterando;
                return true;
            }

            if (_actual == null)
            {
                _estado = EstadoIterador.Finalizado;
                return false;
            }

            if (_actual is Tarea)
            {
                _actual = null;
                return true;
            }
            else
            {
                // iterar hijos
                return true;
            }
        }
        public void Reset()
        {
            _actual = _inicial;
        }

        public IElemento Current
        {
            get
            {
                return _actual;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}