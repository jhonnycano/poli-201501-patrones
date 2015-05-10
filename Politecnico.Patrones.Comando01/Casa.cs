#region
using Politecnico.Patrones.Comando01.Perifericos;

#endregion

namespace Politecnico.Patrones.Comando01 {
    /// <summary>
    ///     Por ahora son propiedades del objeto, más adelante podría pensarse en colecciones de objetos
    /// </summary>
    public class Casa {
        public Bombillo BombilloSala;
        public Bombillo BombilloCocina;
        public EquipoSonido EquipoSonidoSala;
        public Televisor TelevisorSala;
        public Casa() {
            BombilloSala = new Bombillo("sala");
            BombilloCocina = new Bombillo("cocina");
            EquipoSonidoSala = new EquipoSonido("sala");
            TelevisorSala = new Televisor("sala");
        }
    }
}