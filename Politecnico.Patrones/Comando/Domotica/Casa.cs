using Politecnico.Patrones.Comando.Domotica.Perifericos;

namespace Politecnico.Patrones.Comando.Domotica {
    /// <summary>
    /// Por ahora son propiedades del objeto, más adelante podría pensarse en colecciones de objetos
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
