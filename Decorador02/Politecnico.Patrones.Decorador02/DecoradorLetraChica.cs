﻿namespace Politecnico.Patrones.Decorador02 {
    public class DecoradorLetraChica : DecoradorHtmlBase {
        public DecoradorLetraChica() {
        }

        public DecoradorLetraChica(IDecoradorHtml decorador) : base(decorador) {
        }

        protected override string DecorarInterno(string entrada) {
            return "<small>" + entrada + "</small>";
        }
    }
}