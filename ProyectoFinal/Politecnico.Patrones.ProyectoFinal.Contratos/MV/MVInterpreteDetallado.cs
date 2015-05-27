using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.MV {
    public class MVInterpreteDetallado : MVInterprete {
        public IList<MVAlbumDetallado> Albumes { get; set; }
        public MVCancionLista CancionesSinAlbum { get; set; }
    }
}