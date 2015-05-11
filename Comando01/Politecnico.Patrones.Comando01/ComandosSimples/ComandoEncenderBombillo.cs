#region
using Politecnico.Patrones.Comando01.Perifericos;

#endregion

namespace Politecnico.Patrones.Comando01.ComandosSimples {
    public class ComandoEncenderBombillo : IComando {
        private readonly Bombillo _bombillo;
        public ComandoEncenderBombillo(Bombillo bombillo) {
            _bombillo = bombillo;
        }
        public void Ejecutar() {
            _bombillo.Encender();
        }
    }
}