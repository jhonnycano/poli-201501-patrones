namespace Politecnico.Patrones.ProyectoFinal.Lib.VO {
    public class AsociarCancionYAlbumEntrada {
        public enum Acciones {
            Asociar,
            Desasociar
        }

        public int CancionId { get; set; }
        public int AlbumId { get; set; }
        public Acciones Accion { get; set; }
    }
}