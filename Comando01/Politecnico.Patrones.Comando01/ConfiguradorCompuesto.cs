#region
using Politecnico.Patrones.Comando01.ComandosCompuestos;
using Politecnico.Patrones.Comando01.ComandosSimples;
using Politecnico.Patrones.Comando01.Paneles;

#endregion

namespace Politecnico.Patrones.Comando01 {
    public class ConfiguradorCompuesto {
        private readonly Panel _panel;
        private readonly Casa _casa;
        public ConfiguradorCompuesto(Panel panel, Casa casa) {
            _panel = panel;
            _casa = casa;
        }
        public void RegistrarComandoSilencio(int pos) {
            var cmd = new ComandoSilencio(_casa);
            _panel.RegistrarAccion(pos, "Activar silencio", cmd, ComandoNulo.Nulo);
        }
        public void RegistrarComandoFiesta(int pos) {
            var cmd = new ComandoFiesta(_casa);
            _panel.RegistrarAccion(pos, "Activar fiesta", cmd, ComandoNulo.Nulo);
        }
    }
}