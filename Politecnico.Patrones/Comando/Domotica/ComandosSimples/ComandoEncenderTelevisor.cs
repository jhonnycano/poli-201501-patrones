using Politecnico.Patrones.Comando.Domotica.Perifericos;

namespace Politecnico.Patrones.Comando.Domotica.ComandosSimples {
    public class ComandoEncenderTelevisor : IComando {
        private readonly Televisor _televisor;
        public ComandoEncenderTelevisor(Televisor televisor) {
            _televisor = televisor;
        }
        public void Ejecutar() {
            _televisor.Encender();
        }
    }
}