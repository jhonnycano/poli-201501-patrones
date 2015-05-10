#region
using Politecnico.Patrones.Comando01.Perifericos;

#endregion

namespace Politecnico.Patrones.Comando01.ComandosSimples {
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