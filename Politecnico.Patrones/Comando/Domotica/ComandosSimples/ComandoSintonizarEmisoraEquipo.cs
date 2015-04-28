using Politecnico.Patrones.Comando.Domotica.Perifericos;

namespace Politecnico.Patrones.Comando.Domotica.ComandosSimples {
    public class ComandoSintonizarEmisoraEquipo : IComando {
        private readonly string _emisora;
        private readonly EquipoSonido _equipoSonido;
        public ComandoSintonizarEmisoraEquipo(EquipoSonido equipoSonido, string emisora) {
            _equipoSonido = equipoSonido;
            _emisora = emisora;
        }
        public void Ejecutar() {
            _equipoSonido.SintonizarEmisora(_emisora);
        }
    }
}