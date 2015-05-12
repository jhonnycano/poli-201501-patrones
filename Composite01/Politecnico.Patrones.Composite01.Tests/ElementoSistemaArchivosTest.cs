#region
using System.Text;
using NUnit.Framework;
using Politecnico.Patrones.Composite01.Tests.Recursos;

#endregion

namespace Politecnico.Patrones.Composite01.Tests {
    [TestFixture]
    public class ElementoSistemaArchivosTest {
        [Test]
        public void Imprimir() {
            ElementoSistemaArchivos raiz = ElementoSistemaArchivos.Crear(@"D:\AreaTrabajo\Pruebas");
            var sb = new StringBuilder();
            raiz.Imprimir(sb, 0);
            Assert.AreEqual(Archivos.ResultTest, sb.ToString());
        }
    }
}