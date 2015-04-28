using NUnit.Framework;
using Politecnico.Patrones.Comando.Domotica;
using Politecnico.Patrones.Comando.Domotica.ComandosCompuestos;

namespace Tests.Comando
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
