namespace Politecnico.Patrones.ProyectoFinal.Lib.VO {
    public abstract class SalidaBase {
        public enum Resultados {
            NoDefinido = 0,
            Exito = 1,
            Fallo = 2,
        }

        public Resultados Resultado { get; set; }
        public string Mensaje { get; set; }

        protected SalidaBase() : this(Resultados.NoDefinido) {
        }
        protected SalidaBase(Resultados resultado) {
            Resultado = resultado;
        }
        public static T Fallo<T>(T salida, string mensaje) where T : SalidaBase {
            salida.Resultado = Resultados.Fallo;
            salida.Mensaje = mensaje;
            return salida;
        }
        public static T Exito<T>(T salida, string mensaje = "") where T : SalidaBase {
            salida.Resultado = Resultados.Exito;
            salida.Mensaje = mensaje;
            return salida;
        }
    }
}