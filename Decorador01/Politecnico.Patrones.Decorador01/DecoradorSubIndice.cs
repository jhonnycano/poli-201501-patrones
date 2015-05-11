namespace Politecnico.Patrones.Decorador01 {
    public class DecoradorSubIndice : DecoradorHtmlBase {
        public DecoradorSubIndice() {
        }

        public DecoradorSubIndice(IDecoradorHtml decorador) : base(decorador) {
        }

        protected override string DecorarInterno(string entrada) {
            return "<sub>" + entrada + "</sub>";
        }
    }
}