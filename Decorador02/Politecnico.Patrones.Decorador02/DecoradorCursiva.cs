namespace Politecnico.Patrones.Decorador02 {
    public class DecoradorCursiva : DecoradorHtmlBase {
        public DecoradorCursiva() {
        }

        public DecoradorCursiva(IDecoradorHtml decorador) : base(decorador) {
        }

        protected override string DecorarInterno(string entrada) {
            return "<em>" + entrada + "</em>";
        }
    }
}