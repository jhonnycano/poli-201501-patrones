using NUnit.Framework;
using Politecnico.Patrones.Comando01.ComandosCompuestos;

namespace Politecnico.Patrones.Comando01.Tests
{
    [TestFixture]
    class ComandoFiestaTest
    {
        [Test]
        public void Completo() {
            var casa = new Casa();
            var cmd = new ComandoFiesta(casa);
            cmd.Ejecutar();
        }
    }
}
