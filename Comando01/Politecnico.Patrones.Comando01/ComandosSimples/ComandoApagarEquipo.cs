#region
using Politecnico.Patrones.Comando01.Perifericos;

#endregion

namespace Politecnico.Patrones.Comando01.ComandosSimples {
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