using NUnit.Framework;

namespace Politecnico.Patrones.Decorador01.Tests
{
    [TestFixture]
    internal class DecoradorHtmlTest
    {
        [Test]
        public void DecoradorAcentos()
        {
            var cadena = new DecoradorAcentos();

            string result = cadena.Decorar("Jaime Peña García");
            Assert.AreEqual("Jaime Pe&ntilde;a Garc&iacute;a", result);
        }

        [Test]
        public void DecoradorFuenteHtml4()
        {
            var cadena = new DecoradorFuenteHtml4(new DecoradorFuenteHtml4.Parametros {Color = "#333333", Tam = "16px", Tipo = "Garamond"});

            string result = cadena.Decorar("En verdes praderas me hace recostar");
            Assert.AreEqual("<font color='#333333' face='Garamond' size='16px'>En verdes praderas me hace recostar</font>", result);
        }

        [Test]
        public void VariosDecoradores()
        {
            var cadena = new DecoradorAcentos(
                new DecoradorBarraHorizontalDespues(
                    new DecoradorCursiva(
                        new DecoradorNegrilla()
                        )
                    ));

            string result = cadena.Decorar("hola Mariú");
            Assert.AreEqual("<em><strong>hola Mari&uacute;</strong></em><hr />", result);
        }
    }
}