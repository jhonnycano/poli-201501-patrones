using Politecnico.Patrones.Comando.Domotica.Perifericos;

namespace Politecnico.Patrones.Comando.Domotica.ComandosSimples {
    public class ComandoApagarTelevisor : IComando {
        private readonly Televisor _televisor;
        public ComandoApagarTelevisor(Televisor televisor) {
            _televisor = televisor;
        }
        public void Ejecutar() {
            _televisor.Apagar();
        }
    }
}