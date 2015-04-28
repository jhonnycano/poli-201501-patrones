using System.Collections.Generic;

namespace Politecnico.Patrones.Fabrica.DistribucionCurules
{
    public interface IAlgoritmoDistribucionCurules
    {
        void Calcular(IList<InfoPartido> partidos, int curulesDisponibles);
    }
}