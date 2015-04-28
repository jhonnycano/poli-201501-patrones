using Politecnico.Patrones.Comando.Domotica.Perifericos;

namespace Politecnico.Patrones.Comando.Domotica.ComandosSimples {
    public class ComandoApagarEquipo : IComando {
        private readonly EquipoSonido _equipoSonido;
        public ComandoApagarEquipo(EquipoSonido equipoSonido) {
            _equipoSonido = equipoSonido;
        }
        public void Ejecutar() {
            _equipoSonido.Apagar();
        }
    }
}