using System.Collections.Generic;

namespace Politecnico.Patrones.Estrategia01 {
    public interface IAlgoritmoDistribucionCurules {
        void Calcular(IList<InfoPartido> partidos, int curulesDisponibles);
    }
}