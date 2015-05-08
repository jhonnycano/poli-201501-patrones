using System.Diagnostics;

namespace Politecnico.Patrones.Estrategia01
{
    [DebuggerDisplay("{Nombre}:{VotosGanados}, {CurulesAsignadas}")]
    public class InfoPartido
    {
        public string Nombre { get; set; }
        public int VotosGanados { get; set; }
        public int CurulesAsignadas { get; set; }
    }
}