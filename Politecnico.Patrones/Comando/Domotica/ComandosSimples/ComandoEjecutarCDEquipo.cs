using Politecnico.Patrones.Comando.Domotica.Perifericos;

namespace Politecnico.Patrones.Comando.Domotica.ComandosSimples {
    public class ComandoEjecutarCDEquipo : IComando {
        private readonly string _cd;
        private readonly EquipoSonido _equipoSonido;
        public ComandoEjecutarCDEquipo(EquipoSonido equipoSonido, string cd) {
            _equipoSonido = equipoSonido;
            _cd = cd;
        }
        public void Ejecutar() {
            _equipoSonido.ExtraerCD();
            _equipoSonido.InsertarCD(_cd);
        }
    }
}