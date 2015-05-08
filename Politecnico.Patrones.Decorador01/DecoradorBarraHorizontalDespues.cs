namespace Politecnico.Patrones.Decorador.DecoradorHtml {
    public class DecoradorBarraHorizontalDespues : DecoradorHtmlBase {
        public DecoradorBarraHorizontalDespues() { }
        public DecoradorBarraHorizontalDespues(IDecoradorHtml decorador) : base(decorador) { }

        protected override string DecorarInterno(string entrada) {
            return entrada + "<hr />";
        }
    }
}