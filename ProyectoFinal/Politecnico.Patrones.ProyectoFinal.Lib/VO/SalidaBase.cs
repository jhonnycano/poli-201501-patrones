namespace Politecnico.Patrones.ProyectoFinal.Lib.VO {
    public abstract class SalidaBase {
        public enum Resultados {
            NoDefinido = 0,
            Exito = 1,
            Fallo = 2,
        }

        public Resultados Resultado { get; set; }

        protected SalidaBase(Resultados resultado) {
            Resultado = resultado;
        }
    }
}