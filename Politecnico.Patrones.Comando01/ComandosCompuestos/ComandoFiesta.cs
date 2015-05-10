namespace Politecnico.Patrones.Comando01.ComandosCompuestos {
    public class ComandoFiesta : ComandoMultiple {
        public ComandoFiesta(Casa casa)
            : base(UtilDomotica.CrearComandosFiesta(casa)) {
        }
    }
}