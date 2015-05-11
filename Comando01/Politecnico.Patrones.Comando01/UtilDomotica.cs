#region
using System.Collections.Generic;
using Politecnico.Patrones.Comando01.ComandosSimples;

#endregion

namespace Politecnico.Patrones.Comando01 {
    public static class UtilDomotica {
        public static IList<IComando> CrearComandosFiesta(Casa casa) {
            return new List<IComando>
                {
                    new ComandoEncenderBombillo(casa.Bombillos["sala"]),
                    new ComandoEncenderBombillo(casa.Bombillos["cocina"]),
                    new ComandoEncenderEquipo(casa.EquiposSonido["sala"]),
                    new ComandoSintonizarEmisoraEquipo(casa.EquiposSonido["sala"], "Blu Radio"),
                    new ComandoEncenderTelevisor(casa.Televisores["sala"]),
                    new ComandoSintonizarCanalTelevisor(casa.Televisores["sala"], "AXN"),
                };
        }
        public static IList<IComando> CrearComandosSilencio(Casa casa) {
            return new List<IComando>
                {
                    new ComandoApagarBombillo(casa.Bombillos["sala"]),
                    new ComandoApagarBombillo(casa.Bombillos["cocina"]),
                    new ComandoApagarEquipo(casa.EquiposSonido["sala"]),
                    new ComandoApagarTelevisor(casa.Televisores["sala"]),
                };
        }
    }
}