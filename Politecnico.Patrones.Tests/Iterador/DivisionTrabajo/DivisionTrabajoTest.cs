using NUnit.Framework;
using Politecnico.Patrones.Iterador.DivisionTrabajo;

namespace Tests.Iterador.DivisionTrabajo
{
    [TestFixture]
    public class DivisionTrabajoTest
    {
        [Test]
        public void Simple()
        {
            IElemento estructura = UtilDivisionTrabajo.CrearEstructura();
            var result = estructura.TraerResumen();
            Assert.AreEqual(Recursos.Archivos.ResumenEsperadoProyecto2, result);
        }
    }
}