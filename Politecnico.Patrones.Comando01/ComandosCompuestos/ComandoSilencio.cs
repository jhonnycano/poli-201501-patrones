namespace Politecnico.Patrones.Comando01.ComandosCompuestos {
    public class ComandoSilencio : ComandoMultiple {
        public ComandoSilencio(Casa casa)
            : base(UtilDomotica.CrearComandosHesicasta(casa)) {
        }
    }
}