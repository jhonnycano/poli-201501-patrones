using Politecnico.Patrones.Comando01.Perifericos;

namespace Politecnico.Patrones.Comando01.ComandosSimples {
    public class ComandoCerrarCortina : IComando {
        private readonly Cortina _cortina;
        public ComandoCerrarCortina(Cortina cortina) {
            _cortina = cortina;
        }
        public void Ejecutar() {
            _cortina.Cerrar();
        }
    }
}