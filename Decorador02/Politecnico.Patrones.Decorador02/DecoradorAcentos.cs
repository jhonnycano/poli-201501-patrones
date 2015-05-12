#region

using System.Collections.Generic;
using System.IO;
using System.Text;
using Politecnico.Patrones.Decorador02.Recursos;

#endregion

namespace Politecnico.Patrones.Decorador02 {
    public class DecoradorAcentos : DecoradorHtmlBase {
        private static IDictionary<string, string> _reemplazos;

        public DecoradorAcentos() {
        }

        public DecoradorAcentos(IDecoradorHtml decorador)
            : base(decorador) {
        }

        protected override string DecorarInterno(string entrada) {
            var reemplazos = CargarReemplazos();
            var sb = new StringBuilder(entrada);

            foreach (var reemplazo in reemplazos) {
                sb.Replace(reemplazo.Key, reemplazo.Value);
            }
            return sb.ToString();
        }

        private IEnumerable<KeyValuePair<string, string>> CargarReemplazos() {
            if (_reemplazos != null) return _reemplazos;
            _reemplazos = new Dictionary<string, string>();
            using (var sr = new StringReader(Archivos.ReemplazosAcentos)) {
                string linea;
                while ((linea = sr.ReadLine()) != null) {
                    var arr = linea.Split('\t');
                    if (arr.Length != 2) continue;

                    _reemplazos[arr[0]] = arr[1];
                }
            }

            return _reemplazos;
        }
    }
}