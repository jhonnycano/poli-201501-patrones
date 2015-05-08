using NUnit.Framework;
using Politecnico.Patrones.Estrategia01.Distribuciones;

namespace Politecnico.Patrones.Estrategia01.Tests
{
    [TestFixture]
    public class DistribucionRestoMayorTest
    {
        [Test]
        public void EsquemaVotacion1()
        {
            var algo = new DistribucionRestoMayor(MetodoDistribucion.Hare);
            var partidos = UtilDistribucion.TraerVotaciones(UtilDistribucion.EsquemaVotacion.Esquema1);
            algo.Calcular(partidos, 8);

            UtilDistribucion.Verificar(partidos, "P1", 3);
            UtilDistribucion.Verificar(partidos, "P2", 3);
            UtilDistribucion.Verificar(partidos, "P3", 1);
            UtilDistribucion.Verificar(partidos, "P4", 1);
        }
        [Test]
        public void EsquemaVotacion2()
        {
            var algo = new DistribucionRestoMayor(MetodoDistribucion.Hare);
            var partidos = UtilDistribucion.TraerVotaciones(UtilDistribucion.EsquemaVotacion.Esquema2);
            algo.Calcular(partidos, 7);

            UtilDistribucion.Verificar(partidos, "P1", 3);
            UtilDistribucion.Verificar(partidos, "P2", 2);
            UtilDistribucion.Verificar(partidos, "P3", 1);
            UtilDistribucion.Verificar(partidos, "P4", 1);
            UtilDistribucion.Verificar(partidos, "P5", 0);
        }
        [Test]
        public void EsquemaVotacion3_Hare()
        {
            var algo = new DistribucionRestoMayor(MetodoDistribucion.Hare);
            var partidos = UtilDistribucion.TraerVotaciones(UtilDistribucion.EsquemaVotacion.Esquema3);
            algo.Calcular(partidos, 21);

            UtilDistribucion.Verificar(partidos, "P1", 8);
            UtilDistribucion.Verificar(partidos, "P2", 6);
            UtilDistribucion.Verificar(partidos, "P3", 4);
            UtilDistribucion.Verificar(partidos, "P4", 2);
            UtilDistribucion.Verificar(partidos, "P5", 1);
            UtilDistribucion.Verificar(partidos, "P6", 0);
            UtilDistribucion.Verificar(partidos, "P7", 0);
        }
        [Test]
        public void EsquemaVotacion3_Droop()
        {
            var algo = new DistribucionRestoMayor(MetodoDistribucion.Droop);
            var partidos = UtilDistribucion.TraerVotaciones(UtilDistribucion.EsquemaVotacion.Esquema3);
            algo.Calcular(partidos, 21);

            UtilDistribucion.Verificar(partidos, "P1", 8);
            UtilDistribucion.Verificar(partidos, "P2", 7);
            UtilDistribucion.Verificar(partidos, "P3", 4);
            UtilDistribucion.Verificar(partidos, "P4", 2);
            UtilDistribucion.Verificar(partidos, "P5", 0);
            UtilDistribucion.Verificar(partidos, "P6", 0);
            UtilDistribucion.Verificar(partidos, "P7", 0);
        }
        [Test]
        public void EsquemaVotacion3_Imperiali()
        {
            var algo = new DistribucionRestoMayor(MetodoDistribucion.Imperiali);
            var partidos = UtilDistribucion.TraerVotaciones(UtilDistribucion.EsquemaVotacion.Esquema3);
            algo.Calcular(partidos, 21);

            UtilDistribucion.Verificar(partidos, "P1", 9);
            UtilDistribucion.Verificar(partidos, "P2", 7);
            UtilDistribucion.Verificar(partidos, "P3", 4);
            UtilDistribucion.Verificar(partidos, "P4", 1);
            UtilDistribucion.Verificar(partidos, "P5", 0);
            UtilDistribucion.Verificar(partidos, "P6", 0);
            UtilDistribucion.Verificar(partidos, "P7", 0);
        }
    }
}