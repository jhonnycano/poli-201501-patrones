namespace Politecnico.Patrones.Comando.Domotica.ComandosCompuestos {
    public class ComandoFiesta : ComandoMultiple {
        public ComandoFiesta(Casa casa)
            : base(UtilDomotica.CrearComandosFiesta(casa)) {
        }
    }
}