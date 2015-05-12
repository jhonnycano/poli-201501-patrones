namespace Politecnico.Patrones.Decorador02 {
    public class DecoradorNegrilla : DecoradorHtmlBase {
        public DecoradorNegrilla() {
        }

        public DecoradorNegrilla(IDecoradorHtml decorador) : base(decorador) {
        }

        protected override string DecorarInterno(string entrada) {
            return "<strong>" + entrada + "</strong>";
        }
    }
}