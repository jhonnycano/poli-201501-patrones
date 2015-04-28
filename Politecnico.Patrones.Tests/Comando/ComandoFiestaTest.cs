using NUnit.Framework;
using Politecnico.Patrones.Comando.Domotica;
using Politecnico.Patrones.Comando.Domotica.ComandosCompuestos;

namespace Tests.Comando
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
