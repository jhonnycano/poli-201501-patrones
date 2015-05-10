using NUnit.Framework;

namespace Politecnico.Patrones.Decorador01.Tests {
    [TestFixture]
    public class DecoradorHtmlTest {
        [Test]
        public void DecoradorAcentos() {
            var decoradores = new DecoradorAcentos();

            string result = decoradores.Decorar("Mariú Ramírez CELEBRÓ mi cumpleaños");
            Assert.AreEqual("Mari&uacute; Ram&iacute;rez CELEBR&Oacute; mi cumplea&ntilde;os", result);
        }

        [Test]
        public void DecoradorFuente() {
            var paramD1 = new DecoradorFuenteHtml4.Parametros
                {
                    Color = "#bffbbf",
                    Tam = "16px",
                    Tipo = "Arial"
                };
            var d1 = new DecoradorFuenteHtml4(paramD1);

            var paramD2 = new DecoradorFuenteHtml4.Parametros {Color = "#bffbbf", Tam = "16px"};
            var d2 = new DecoradorFuenteHtml4(paramD2);


            var paramD3 = new DecoradorFuenteHtml4.Parametros {Color = "#bffbbf"};
            var d3 = new DecoradorFuenteHtml4(paramD3);

            string r1 = d1.Decorar("Esto es una prueba");
            Assert.AreEqual("<font color='#bffbbf' face='Arial' size='16px'>Esto es una prueba</font>", r1);

            string r2 = d2.Decorar("Esto es una prueba");
            Assert.AreEqual("<font color='#bffbbf' size='16px'>Esto es una prueba</font>", r2);

            string r3 = d3.Decorar("Esto es una prueba");
            Assert.AreEqual("<font color='#bffbbf'>Esto es una prueba</font>", r3);
        }

        [Test]
        public void VariosDecoradores() {
            var decoradores = new DecoradorBarraHorizontalDespues(
                new DecoradorCursiva(
                    new DecoradorNegrilla()
                    )
                );

            string result = decoradores.Decorar("hola mundo");
            Assert.AreEqual("<em><strong>hola mundo</strong></em><hr />", result);
        }
    }
}