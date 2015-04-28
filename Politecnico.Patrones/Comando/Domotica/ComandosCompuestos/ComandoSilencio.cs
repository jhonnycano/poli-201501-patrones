namespace Politecnico.Patrones.Comando.Domotica.ComandosCompuestos {
    public class ComandoSilencio : ComandoMultiple {
        public ComandoSilencio(Casa casa)
            : base(UtilDomotica.CrearComandosHesicasta(casa)) {
        }
    }
}