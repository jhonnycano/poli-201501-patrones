namespace Politecnico.Patrones.ProyectoFinal.Contratos.VO {
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
        public static bool operator ==(SalidaBase salida, Resultados resultado) {
            return salida != null && salida.Resultado == resultado;
        }
        public static bool operator !=(SalidaBase salida, Resultados resultado) {
            return !(salida == resultado);
        }
         protected bool Equals(SalidaBase other) {
            return Resultado == other.Resultado && string.Equals(Mensaje, other.Mensaje);
        }
        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SalidaBase) obj);
        }
        public override int GetHashCode() {
            unchecked {
                return ((int) Resultado*397) ^ (Mensaje != null ? Mensaje.GetHashCode() : 0);
            }
        }
   }
}