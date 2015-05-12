#region
using System.Collections.Generic;
using System.IO;
using System.Text;

#endregion

namespace Politecnico.Patrones.Composite01 {
    public class Archivo : ElementoSistemaArchivos {
        public Archivo(string ruta) {
            Ruta = Path.GetFileName(ruta);
        }
        public override IList<ElementoSistemaArchivos> TraerElementos() {
            return null;
        }
        public override void Imprimir(StringBuilder sb, int indentacion) {
            sb.AppendLine(new string(' ', indentacion) + Ruta);
        }
    }
}