#region
using Politecnico.Patrones.Comando01.Perifericos;

#endregion

namespace Politecnico.Patrones.Comando01.ComandosSimples {
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