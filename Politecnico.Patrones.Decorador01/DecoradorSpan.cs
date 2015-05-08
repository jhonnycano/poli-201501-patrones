namespace Politecnico.Patrones.Decorador.DecoradorHtml {
    public class DecoradorSpan : DecoradorHtmlBase {
        public DecoradorSpan() { }
        public DecoradorSpan(IDecoradorHtml decorador) : base(decorador) { }

        protected override string DecorarInterno(string entrada) {
            return "<span>" + entrada + "</span>";
        }
    }
}