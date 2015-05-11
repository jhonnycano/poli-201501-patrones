#region
using NUnit.Framework;
using Politecnico.Patrones.Comando01.ComandosSimples;
using Politecnico.Patrones.Comando01.Paneles;
using Politecnico.Patrones.Comando01.Perifericos;

#endregion

namespace Politecnico.Patrones.Comando01.Tests {
    [TestFixture]
    public class PanelSimpleTest {
        [Test]
        public void CrearPanelYAgregarComandos() {
            var panel = new PanelSimple(10);
            var bombillo = new Bombillo("habitacion principal");
            panel.RegistrarAccion(5, new ComandoEncenderBombillo(bombillo), new ComandoApagarBombillo(bombillo));

            panel.Activar(5);
            panel.Inactivar(5);
            panel.Activar(6);
        }
    }
}