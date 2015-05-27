using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Lib.MV {
    public class MVAlbumDetallado: MVAlbum {
        public MVAlbumDetallado() {
        }
        public MVAlbumDetallado(Album album) {
            Id = album.Id;
            Nombre = album.Nombre;
        }
        public IList<MVInterprete> Interpretes { get; set; }
        public IList<MVCancion> Canciones { get; set; }
    }
}