#region
using Politecnico.Patrones.Comando01.Perifericos;

#endregion

namespace Politecnico.Patrones.Comando01.ComandosSimples {
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