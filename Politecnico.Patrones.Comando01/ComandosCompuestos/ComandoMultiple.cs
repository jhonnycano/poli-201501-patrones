#region
using System.Collections.Generic;

#endregion

namespace Politecnico.Patrones.Comando01.ComandosCompuestos {
    public class ComandoMultiple : IComando {
        private readonly IList<IComando> _lista;

        public ComandoMultiple(IList<IComando> lista) {
            _lista = lista;
        }

        public void Ejecutar() {
            foreach (IComando cmd in _lista) {
                cmd.Ejecutar();
            }
        }
    }
}