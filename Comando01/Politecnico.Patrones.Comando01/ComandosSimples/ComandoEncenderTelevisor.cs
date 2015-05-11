#region
using Politecnico.Patrones.Comando01.Perifericos;

#endregion

namespace Politecnico.Patrones.Comando01.ComandosSimples {
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