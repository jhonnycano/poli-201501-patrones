#region
using Politecnico.Patrones.Comando01.Perifericos;

#endregion

namespace Politecnico.Patrones.Comando01.ComandosSimples {
    public class ComandoApagarBombillo : IComando {
        private readonly Bombillo _bombillo;
        public ComandoApagarBombillo(Bombillo bombillo) {
            _bombillo = bombillo;
        }
        public void Ejecutar() {
            _bombillo.Apagar();
        }
    }
}