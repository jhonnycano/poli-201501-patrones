using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Lib.MV {
    public class MVAlbumDetallado: MVAlbum {
        public IList<MVInterprete> Interpretes { get; set; }
        public IList<MVCancion> Canciones { get; set; }
    }
}