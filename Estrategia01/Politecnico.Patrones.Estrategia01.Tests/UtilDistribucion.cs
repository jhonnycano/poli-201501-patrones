using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Politecnico.Patrones.Estrategia01.Tests.Recursos;

namespace Politecnico.Patrones.Estrategia01.Tests {
    public static class UtilDistribucion {
        public enum EsquemaVotacion {
            Esquema1,
            Esquema2,
            Esquema3
        }

        public static IList<InfoPartido> TraerVotaciones(EsquemaVotacion esquema) {
            string s = TraerEsquemaVotacion(esquema);
            IList<InfoPartido> result = UtilInfo.TraerInfoPartidos(s);
            return result;
        }

        private static string TraerEsquemaVotacion(EsquemaVotacion esquema) {
            switch (esquema) {
                case EsquemaVotacion.Esquema1:
                    return Archivos.VotacionEsquema1;
                case EsquemaVotacion.Esquema2:
                    return Archivos.VotacionEsquema2;
                case EsquemaVotacion.Esquema3:
                    return Archivos.VotacionEsquema3;
                default:
                    return "";
            }
        }

        public static void Verificar(IList<InfoPartido> partidos, string nombre, int valorEsperado) {
            InfoPartido partido = partidos.First(p => p.Nombre == nombre);
            Assert.AreEqual(valorEsperado, partido.CurulesAsignadas);
        }
    }
}