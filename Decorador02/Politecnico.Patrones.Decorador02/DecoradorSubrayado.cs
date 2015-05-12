namespace Politecnico.Patrones.Decorador02 {
    public class DecoradorSubrayado : DecoradorHtmlBase {
        public DecoradorSubrayado() {
        }

        public DecoradorSubrayado(IDecoradorHtml decorador) : base(decorador) {
        }

        protected override string DecorarInterno(string entrada) {
            return "<u>" + entrada + "</u>";
        }
    }
}