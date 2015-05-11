#region
using Politecnico.Patrones.Comando01.Perifericos;

#endregion

namespace Politecnico.Patrones.Comando01.ComandosSimples {
    public class ComandoAbrirCortina : IComando {
        private readonly Cortina _cortina;
        public ComandoAbrirCortina(Cortina cortina) {
            _cortina = cortina;
        }
        public void Ejecutar() {
            _cortina.Abrir();
        }
    }
}