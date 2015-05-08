using NUnit.Framework;
using Politecnico.Patrones.Estrategia01.Distribuciones;

namespace Politecnico.Patrones.Estrategia01.Tests
{
    [TestFixture]
    public class DistribucionSaintLagueSimpleTest
    {
        [Test]
        public void EsquemaVotacion1()
        {
            var algo = new DistribucionSaintLagueSimple();
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
            var algo = new DistribucionSaintLagueSimple();
            var partidos = UtilDistribucion.TraerVotaciones(UtilDistribucion.EsquemaVotacion.Esquema2);
            algo.Calcular(partidos, 7);

            UtilDistribucion.Verificar(partidos, "P1", 3);
            UtilDistribucion.Verificar(partidos, "P2", 2);
            UtilDistribucion.Verificar(partidos, "P3", 1);
            UtilDistribucion.Verificar(partidos, "P4", 1);
            UtilDistribucion.Verificar(partidos, "P5", 0);
        }
    }
}