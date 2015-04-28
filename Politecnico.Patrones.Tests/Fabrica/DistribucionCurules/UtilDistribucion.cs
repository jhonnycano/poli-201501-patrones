using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Politecnico.Patrones;
using Politecnico.Patrones.Fabrica.DistribucionCurules;

namespace Tests.DistribucionCurules
{
    public static class UtilDistribucion
    {
        public enum EsquemaVotacion { Esquema1, Esquema2, Esquema3 }
        public static IList<InfoPartido> TraerVotaciones(EsquemaVotacion esquema)
        {
            var s = TraerEsquemaVotacion(esquema);
            var result = UtilInfo.TraerInfoPartidos(s);
            return result;
        }

        private static string TraerEsquemaVotacion(EsquemaVotacion esquema)
        {
            switch (esquema)
            {
                case EsquemaVotacion.Esquema1: return Recursos.Archivos.VotacionEsquema1;
                case EsquemaVotacion.Esquema2: return Recursos.Archivos.VotacionEsquema2;
                case EsquemaVotacion.Esquema3: return Recursos.Archivos.VotacionEsquema3;
                default: return "";
            }
        }

        public static void Verificar(IList<InfoPartido> partidos, string nombre, int valorEsperado)
        {
            var partido = partidos.First(p => p.Nombre == nombre);
            Assert.AreEqual(valorEsperado, partido.CurulesAsignadas);
        }
    }
}
