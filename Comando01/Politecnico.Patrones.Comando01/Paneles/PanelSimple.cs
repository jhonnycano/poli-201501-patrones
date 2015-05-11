#region
using System;
using System.Collections.Generic;
using Politecnico.Patrones.Comando01.ComandosSimples;

#endregion

namespace Politecnico.Patrones.Comando01.Paneles {
    public class PanelSimple {
        private const int MaximoComandos = 20;
        private readonly List<IComando> _comandosActivar;
        private readonly List<IComando> _comandosInactivar;
        public PanelSimple(int cantidadComandos) {
            if (cantidadComandos < 1) throw new ApplicationException("Cantidad de comandos no válida");
            if (cantidadComandos > MaximoComandos) throw new ApplicationException("Cantidad de comandos no válida");

            _comandosActivar = new List<IComando>(cantidadComandos);
            _comandosInactivar = new List<IComando>(cantidadComandos);

            for (int i = 0; i < cantidadComandos; i++) {
                _comandosActivar.Add(ComandoNulo.Nulo);
                _comandosInactivar.Add(ComandoNulo.Nulo);
            }
        }
        public void RegistrarAccion(int pos, IComando comandoActivar, IComando comandoInactivar) {
            _comandosActivar[pos] = comandoActivar;
            _comandosInactivar[pos] = comandoInactivar;
        }
        public void Activar(int pos) {
            _comandosActivar[pos].Ejecutar();
        }
        public void Inactivar(int pos) {
            _comandosInactivar[pos].Ejecutar();
        }
    }
}