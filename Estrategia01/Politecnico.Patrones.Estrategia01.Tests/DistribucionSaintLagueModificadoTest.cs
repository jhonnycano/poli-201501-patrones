using System.Collections.Generic;
using NUnit.Framework;
using Politecnico.Patrones.Estrategia01.Distribuciones;

namespace Politecnico.Patrones.Estrategia01.Tests
{
    [TestFixture]
    public class DistribucionSaintLagueModificadoTest
    {
        [Test]
        public void EsquemaVotacion1()
        {
            var algo = new DistribucionSaintLagueModificado();
            IList<InfoPartido> partidos = UtilDistribucion.TraerVotaciones(UtilDistribucion.EsquemaVotacion.Esquema1);
            algo.Calcular(partidos, 8);

            UtilDistribucion.Verificar(partidos, "P1", 3);
            UtilDistribucion.Verificar(partidos, "P2", 2);
            UtilDistribucion.Verificar(partidos, "P3", 2);
            UtilDistribucion.Verificar(partidos, "P4", 1);
        }

        [Test]
        public void EsquemaVotacion2()
        {
            var algo = new DistribucionSaintLagueModificado();
            IList<InfoPartido> partidos = UtilDistribucion.TraerVotaciones(UtilDistribucion.EsquemaVotacion.Esquema2);
            algo.Calcular(partidos, 7);

            UtilDistribucion.Verificar(partidos, "P1", 3);
            UtilDistribucion.Verificar(partidos, "P2", 2);
            UtilDistribucion.Verificar(partidos, "P3", 2);
            UtilDistribucion.Verificar(partidos, "P4", 0);
            UtilDistribucion.Verificar(partidos, "P5", 0);
        }
    }
}