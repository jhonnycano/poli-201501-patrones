#region
using NUnit.Framework;
using Politecnico.Patrones.Comando01.ComandosSimples;
using Politecnico.Patrones.Comando01.Paneles;

#endregion

namespace Politecnico.Patrones.Comando01.Tests {
    [TestFixture]
    public class CasaTest {
        [Test]
        public void UsarCasa() {
            var c = new Casa();
            var bombilloSala = c.RegistrarBombillo("sala");
            var bombilloCocina = c.RegistrarBombillo("cocina");
            var equipoSonidoSala = c.RegistrarEquipoSonido("sala");
            var televisorSala = c.RegistrarTelevisor("sala");
            var cortinaSala = c.RegistrarCortina("sala");

            var panel = new Panel(10);
            panel.RegistrarAccion(0, "Bombillo", new ComandoEncenderBombillo(bombilloSala), new ComandoApagarBombillo(bombilloSala));
        }
    }
}