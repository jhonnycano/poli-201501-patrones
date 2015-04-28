using NUnit.Framework;
using Politecnico.Patrones.Decorador.DecoradorHtml;

namespace Tests.DecoradorHtml
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

            var result = cadena.Decorar("hola mundo");
            Assert.AreEqual("<em><strong>hola mundo</strong></em><hr />", result);
        }
    }
}