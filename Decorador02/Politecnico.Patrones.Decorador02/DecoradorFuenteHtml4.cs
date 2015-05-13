#region
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Politecnico.Patrones.Decorador02 {
    public class DecoradorFuenteHtml4 : DecoradorHtmlBase {
        private readonly Parametros _parametros;

        public DecoradorFuenteHtml4(Parametros parametros) {
            _parametros = parametros;
        }

        public DecoradorFuenteHtml4(IDecoradorHtml decorador, Parametros parametros)
            : base(decorador) {
            _parametros = parametros;
        }

        public DecoradorFuenteHtml4(IDecoradorHtml decorador, string parametros)
            : base(decorador) {
            _parametros = CrearParametrosDesdeString(parametros);
        }

        private Parametros CrearParametrosDesdeString(string parametros) {
            return JsonConvert.DeserializeObject<Parametros>(parametros);
        }

        protected override string DecorarInterno(string entrada) {
            const string plantillaPreproceso = "<font@@detalle>@@entrada</font>";
            var sb = new StringBuilder();
            if (_parametros.Color != null) sb.Append(" color='" + _parametros.Color + "'");
            if (_parametros.Tipo != null) sb.Append(" face='" + _parametros.Tipo + "'");
            if (_parametros.Tam != null) sb.Append(" size='" + _parametros.Tam + "'");

            var result = plantillaPreproceso
                .Replace("@@detalle", sb.ToString())
                .Replace("@@entrada", entrada);

            return result;
        }

        public class Parametros {
            public string Color { get; set; }
            public string Tipo { get; set; }
            public string Tam { get; set; }
        }
    }
}