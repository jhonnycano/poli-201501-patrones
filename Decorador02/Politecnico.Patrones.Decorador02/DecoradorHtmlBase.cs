namespace Politecnico.Patrones.Decorador02 {
    public abstract class DecoradorHtmlBase : IDecoradorHtml {
        private readonly IDecoradorHtml _decorador;

        protected DecoradorHtmlBase(IDecoradorHtml decorador) {
            _decorador = decorador;
        }

        protected DecoradorHtmlBase() : this(null) {
        }

        public string Decorar(string entrada) {
            if (_decorador == null) {
                return DecorarInterno(entrada);
            }
            return DecorarInterno(_decorador.Decorar(entrada));
        }

        protected abstract string DecorarInterno(string entrada);
    }
}