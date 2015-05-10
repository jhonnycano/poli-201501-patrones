namespace Politecnico.Patrones.Decorador01 {
    public class DecoradorBarraHorizontalDespues : DecoradorHtmlBase {
        public DecoradorBarraHorizontalDespues() {
        }

        public DecoradorBarraHorizontalDespues(IDecoradorHtml decorador) : base(decorador) {
        }

        protected override string DecorarInterno(string entrada) {
            return entrada + "<hr />";
        }
    }
}