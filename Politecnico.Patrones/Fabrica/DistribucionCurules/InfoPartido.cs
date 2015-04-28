using System.Diagnostics;

namespace Politecnico.Patrones.Fabrica.DistribucionCurules
{
    [DebuggerDisplay("{Nombre}:{VotosGanados}, {CurulesAsignadas}")]
    public class InfoPartido
    {
        public string Nombre { get; set; }
        public int VotosGanados { get; set; }
        public int CurulesAsignadas { get; set; }
    }
}
