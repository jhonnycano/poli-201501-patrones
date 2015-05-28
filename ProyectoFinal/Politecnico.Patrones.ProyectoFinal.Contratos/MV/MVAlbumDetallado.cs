using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.MV {
    public class MVAlbumDetallado : MVAlbum {
        public MVAlbumDetallado() {
        }
        public MVAlbumDetallado(Album album) {
            Id = album.Id;
            VotableId = album.VotableId;
            Nombre = album.Nombre;
            AñoLanzamiento = album.AñoLanzamiento;
            FchCreacion = album.FchCreacion;
        }
        public MVAlbumDetallado(MVAlbum album) {
            Id = album.Id;
            VotableId = album.VotableId;
            Nombre = album.Nombre;
            AñoLanzamiento = album.AñoLanzamiento;
            FchCreacion = album.FchCreacion;
            TotalVotos = album.TotalVotos;
        }
        public IList<MVInterprete> Interpretes { get; set; }
        public IList<MVCancion> Canciones { get; set; }
    }
}