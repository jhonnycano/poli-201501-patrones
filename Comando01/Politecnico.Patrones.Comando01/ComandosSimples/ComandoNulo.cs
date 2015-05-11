namespace Politecnico.Patrones.Comando01.ComandosSimples {
    public class ComandoNulo : IComando {
        public static ComandoNulo Nulo = new ComandoNulo();
        private ComandoNulo() {
        }
        public void Ejecutar() {
        }
    }
}