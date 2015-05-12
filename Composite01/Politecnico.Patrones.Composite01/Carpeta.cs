#region
using System.Collections.Generic;
using System.IO;
using System.Text;

#endregion

namespace Politecnico.Patrones.Composite01 {
    public class Carpeta : ElementoSistemaArchivos {
        private readonly IList<ElementoSistemaArchivos> _elementos;
        public Carpeta(string ruta) {
            Ruta = Path.GetFileName(ruta);
            _elementos = new List<ElementoSistemaArchivos>();
            foreach (var fse in Directory.GetFileSystemEntries(ruta)) {
                _elementos.Add(Crear(fse));
            }
        }
        public override IList<ElementoSistemaArchivos> TraerElementos() {
            return _elementos;
        }
        public override void Imprimir(StringBuilder sb, int indentacion) {
            sb.AppendLine(new string(' ', indentacion) + Ruta);
            indentacion += 2;
            foreach (var elemento in _elementos) {
                elemento.Imprimir(sb, indentacion);
            }
        }
    }
}