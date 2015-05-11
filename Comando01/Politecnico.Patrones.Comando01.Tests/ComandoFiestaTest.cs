#region
using NUnit.Framework;
using Politecnico.Patrones.Comando01.ComandosCompuestos;

#endregion

namespace Politecnico.Patrones.Comando01.Tests {
    [TestFixture]
    internal class ComandoFiestaTest {
        [Test]
        public void Completo() {
            var casa = new Casa();
            var cmd = new ComandoFiesta(casa);
            cmd.Ejecutar();
        }
    }
}