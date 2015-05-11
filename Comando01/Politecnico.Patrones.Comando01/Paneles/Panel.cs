#region
using System;
using System.Collections.Generic;
using Politecnico.Patrones.Comando01.ComandosSimples;

#endregion

namespace Politecnico.Patrones.Comando01.Paneles {
    public class Panel {
        private const int MaximoComandos = 20;
        private readonly IList<string> _nombres;
        private readonly IList<IComando> _comandosActivar;
        private readonly IList<IComando> _comandosInactivar;
        public IList<string> Nombres {
            get { return _nombres; }
        }
        public Panel(int cantidadComandos) {
            if (cantidadComandos < 1) throw new ApplicationException("Cantidad de comandos no válida");
            if (cantidadComandos > MaximoComandos) throw new ApplicationException("Cantidad de comandos no válida");

            _nombres = new List<string>(cantidadComandos);
            _comandosActivar = new List<IComando>(cantidadComandos);
            _comandosInactivar = new List<IComando>(cantidadComandos);

            for (int i = 0; i < cantidadComandos; i++) {
                _nombres.Add("Acción no definida");
                _comandosActivar.Add(ComandoNulo.Nulo);
                _comandosInactivar.Add(ComandoNulo.Nulo);
            }
        }
        public void RegistrarAccion(int pos, string nombre, IComando comandoActivar, IComando comandoInactivar) {
            _nombres[pos] = nombre;
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