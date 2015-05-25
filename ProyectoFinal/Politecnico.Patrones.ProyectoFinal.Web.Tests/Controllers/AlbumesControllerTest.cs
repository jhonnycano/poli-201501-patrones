using Moq;
using NUnit.Framework;
using Politecnico.Patrones.ProyectoFinal.Contratos;

namespace Politecnico.Patrones.ProyectoFinal.Web.Tests.Controllers {
    [TestFixture]
    internal class AlbumesControllerTest {
        private Mock<IGestorDominio> _mockGestorDominio;
        [SetUp]
        public void Inicializar() {
            _mockGestorDominio = new Mock<IGestorDominio>();
        }
        /*
        [Test]
        public void CrearSinInterprete_Falla() {
            // inicializar
            var controller = new AlbumesController(_mockGestorDominio.Object);
            var albumEditar = new MVAlbumEditar
                {
                    AlbumNombre = "Album de pruebas",
                    ListaInterpretes = null
                };
            var salida = new EditarAlbumSalida
                {
                    Resultado = SalidaBase.Resultados.Fallo,
                    Mensaje = Cadenas.album_falta_interprete,
                    Album = null
                };
            _mockGestorDominio.Setup(gd => gd.EditarAlbum(It.IsAny<EditarAlbumEntrada>())).Returns(salida);

            // probar
            ViewResult result = controller.Crear(albumEditar) as ViewResult;
            
            // verificar
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreEqual("error: " + Cadenas.album_falta_interprete, result.ViewBag.Mensaje);
        }
         * */
    }
}