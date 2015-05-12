#region
using System.Collections.Generic;
using System.IO;
using System.Text;

#endregion

namespace Politecnico.Patrones.Composite01 {
    public abstract class ElementoSistemaArchivos {
        public static ElementoSistemaArchivos Crear(string ruta) {
            if (Directory.Exists(ruta)) {
                return new Carpeta(ruta);
            }
            if (File.Exists(ruta)) {
                return new Archivo(ruta);
            }
            return null;
        }
        public string Ruta { get; internal set; }
        public abstract IList<ElementoSistemaArchivos> TraerElementos();
        public abstract void Imprimir(StringBuilder sb, int indentacion);
    }
}