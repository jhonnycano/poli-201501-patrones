using System.Collections.Generic;
using Politecnico.Patrones.Comando.Domotica.ComandosSimples;

namespace Politecnico.Patrones.Comando.Domotica {
    public static class UtilDomotica {
        public static IList<IComando> CrearComandosFiesta(Casa casa) {
            return new List<IComando>
                {
                    new ComandoEncenderBombillo(casa.BombilloSala),
                    new ComandoEncenderBombillo(casa.BombilloCocina),
                    new ComandoEncenderEquipo(casa.EquipoSonidoSala),
                    new ComandoSintonizarEmisoraEquipo(casa.EquipoSonidoSala, "Blu Radio"),
                    new ComandoEncenderTelevisor(casa.TelevisorSala),
                    new ComandoSintonizarCanalTelevisor(casa.TelevisorSala, "AXN"),
                };
        }
        public static IList<IComando> CrearComandosHesicasta(Casa casa) {
            return new List<IComando>
                {
                    new ComandoApagarBombillo(casa.BombilloSala),
                    new ComandoApagarBombillo(casa.BombilloCocina),
                    new ComandoApagarEquipo(casa.EquipoSonidoSala),
                    new ComandoApagarTelevisor(casa.TelevisorSala),
                };
        }
    }
}