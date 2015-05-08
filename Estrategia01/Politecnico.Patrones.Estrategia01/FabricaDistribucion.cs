using System;
using Politecnico.Patrones.Estrategia01.Distribuciones;

namespace Politecnico.Patrones.Estrategia01
{
    public class FabricaDistribucion
    {
        // ReSharper disable InconsistentNaming
        public enum AlgoritmoDistribucion { DHondt, SaintLague, SaintLagueModificado, RestoMayor_Hare, RestoMayor_Droop, RestoMayor_Imperiali }
        // ReSharper restore InconsistentNaming

        public IAlgoritmoDistribucionCurules TraerAlgoritmo(AlgoritmoDistribucion algoritmo)
        {
            switch (algoritmo)
            {
                case AlgoritmoDistribucion.DHondt: return new DistribucionHondt();
                case AlgoritmoDistribucion.SaintLague: return new DistribucionSaintLagueSimple();
                case AlgoritmoDistribucion.SaintLagueModificado: return new DistribucionSaintLagueModificado();
                case AlgoritmoDistribucion.RestoMayor_Hare: return new DistribucionRestoMayor(MetodoDistribucion.Hare);
                case AlgoritmoDistribucion.RestoMayor_Droop: return new DistribucionRestoMayor(MetodoDistribucion.Droop);
                case AlgoritmoDistribucion.RestoMayor_Imperiali: return new DistribucionRestoMayor(MetodoDistribucion.Imperiali);
                default: throw new ApplicationException("Algoritmo no encontrado: " + algoritmo);
            }
        }
    }
}
