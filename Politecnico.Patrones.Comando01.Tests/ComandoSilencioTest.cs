using NUnit.Framework;
using Politecnico.Patrones.Comando01.ComandosCompuestos;

namespace Politecnico.Patrones.Comando01.Tests
{
    [TestFixture]
    class ComandoSilencioTest
    {
        [Test]
        public void Completo()
        {
            var casa = new Casa();
            var cmd = new ComandoSilencio(casa);
            cmd.Ejecutar();
        }
    }
}
