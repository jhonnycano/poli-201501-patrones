#region
using NUnit.Framework;
using Politecnico.Patrones.Comando01.ComandosCompuestos;

#endregion

namespace Politecnico.Patrones.Comando01.Tests {
    [TestFixture]
    internal class ComandoSilencioTest {
        [Test]
        public void Completo() {
            var casa = new Casa();
            var cmd = new ComandoSilencio(casa);
            cmd.Ejecutar();
        }
    }
}