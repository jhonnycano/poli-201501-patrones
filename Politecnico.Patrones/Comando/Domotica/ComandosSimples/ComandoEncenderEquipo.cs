using Politecnico.Patrones.Comando.Domotica.Perifericos;

namespace Politecnico.Patrones.Comando.Domotica.ComandosSimples {
    public class ComandoEncenderEquipo : IComando {
        private readonly EquipoSonido _equipoSonido;
        public ComandoEncenderEquipo(EquipoSonido equipoSonido) {
            _equipoSonido = equipoSonido;
        }
        public void Ejecutar() {
            _equipoSonido.Encender();
        }
    }
}