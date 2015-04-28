using System.Collections.Generic;
using Politecnico.Patrones.Fabrica.DistribucionCurules;

namespace Politecnico.Patrones.Web.Models
{
    public class InsumoDistribucion
    {
        public string Algoritmo { get; set; }
        public int CurulesDisponibles { get; set; }
        public string ResultadosVotacion { get; set; }
        public IList<InfoPartido> ResultadosCalculados { get; set; }
    }
}