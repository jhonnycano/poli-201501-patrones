using Politecnico.Patrones.Comando.Domotica.Perifericos;

namespace Politecnico.Patrones.Comando.Domotica.ComandosSimples {
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