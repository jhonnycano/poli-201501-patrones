using NUnit.Framework;

namespace Politecnico.Patrones.Decorador01.Tests
{
    [TestFixture]
    internal class DecoradorHtmlTest
    {
        [Test]
        public void VariosDecoradores()
        {
            var cadena = new DecoradorBarraHorizontalDespues(
                new DecoradorCursiva(
                    new DecoradorNegrilla()
                    )
                );

            string result = cadena.Decorar("hola mundo");
            Assert.AreEqual("<em><strong>hola mundo</strong></em><hr />", result);
        }
    }
}