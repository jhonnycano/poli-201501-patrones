namespace Politecnico.Patrones.ProyectoFinal.Contratos.MV {
    public class MVCancionFiltroLista {
        public int Pagina { get; set; }
        public string Nombre { get; set; }
        public FiltroAlbum FiltroAlbum { get; set; }
        public int? Album { get; set; }
    }
}