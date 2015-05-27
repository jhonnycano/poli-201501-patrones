using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos.MV;

namespace Politecnico.Patrones.ProyectoFinal.Lib.MV {
    public class MVInterpreteDetallado : MVInterprete {
        public IList<MVAlbumDetallado> Albumes { get; set; }
        public MVCancionLista CancionesSinAlbum { get; set; }
    }
}