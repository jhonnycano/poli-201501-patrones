using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Lib.MV {
    public class MVInterpreteDetallado : MVInterprete {
        public IList<MVAlbumDetallado> Albumes { get; set; }
        public IList<MVCancion> CancionesSinAlbum { get; set; }
    }
}