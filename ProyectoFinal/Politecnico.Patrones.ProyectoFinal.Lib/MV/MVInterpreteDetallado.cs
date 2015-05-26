using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Lib.MV {
    public class MVInterpreteDetallado {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public IList<MVAlbum> Albumes { get; set; }
        public IList<MVCancion> CancionesSinAlbum { get; set; }
    }
}