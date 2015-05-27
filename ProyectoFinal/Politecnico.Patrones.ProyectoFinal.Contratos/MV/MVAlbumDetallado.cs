using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.MV {
    public class MVAlbumDetallado: MVAlbum {
        public MVAlbumDetallado() {
        }
        public MVAlbumDetallado(Album album) {
            Id = album.Id;
            Nombre = album.Nombre;
        }
        public MVAlbumDetallado(MVAlbum album)
        {
            Id = album.Id;
            Nombre = album.Nombre;
        }
        public IList<MVInterprete> Interpretes { get; set; }
        public IList<MVCancion> Canciones { get; set; }
    }
}