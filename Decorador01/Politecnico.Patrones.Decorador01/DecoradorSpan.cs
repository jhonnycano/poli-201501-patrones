namespace Politecnico.Patrones.Decorador01 {
    public class DecoradorSpan : DecoradorHtmlBase {
        private readonly string _clase;

        public DecoradorSpan() : this(null) {
        }

        public DecoradorSpan(string clase) {
            _clase = clase;
        }

        public DecoradorSpan(IDecoradorHtml decorador, string clase) : base(decorador) {
            _clase = clase;
        }

        protected override string DecorarInterno(string entrada) {
            string exprClase = (string.IsNullOrEmpty(_clase) ? "" : " " + _clase);
            return "<span" + exprClase + ">" + entrada + "</span>";
        }
    }
}