using Politecnico.Patrones.Comando.Domotica.Perifericos;

namespace Politecnico.Patrones.Comando.Domotica.ComandosSimples {
    public class ComandoSintonizarCanalTelevisor : IComando {
        private readonly string _canal;
        private readonly Televisor _televisor;
        public ComandoSintonizarCanalTelevisor(Televisor televisor, string canal) {
            _televisor = televisor;
            _canal = canal;
        }
        public void Ejecutar() {
            _televisor.SintonizarCanal(_canal);
        }
    }
}