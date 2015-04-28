using Politecnico.Patrones.Comando.Domotica.Perifericos;

namespace Politecnico.Patrones.Comando.Domotica.ComandosSimples {
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