using System;
using System.Collections.Generic;
using System.ComponentModel;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.MV {
    public class MVCancion: ICancion {
        public MVCancion() {
        }
        public MVCancion(Cancion cancion) {
            Id = cancion.Id;
            FchCreacion = cancion.FchCreacion;
            Nombre = cancion.Nombre;
            AlbumId = cancion.AlbumId;
            VotableId = cancion.VotableId;
        }
        public MVCancion(MVCancion cancion) {
            Id = cancion.Id;
            FchCreacion = cancion.FchCreacion;
            Nombre = cancion.Nombre;
            AlbumId = cancion.AlbumId;
            VotableId = cancion.VotableId;
        }
        public int Id { get; set; }
        public DateTime FchCreacion { get; set; }
        public string Nombre { get; set; }
        public int VotableId { get; set; }
        public string Album { get; set; }
        public int? AlbumId { get; set; }
        public IList<MVInterprete> Interpretes { get; set; }
        public IList<MVInterprete> InterpretesAlbum { get; set; }
        [DisplayName("Votos")]
        public int TotalVotos { get; set; }
    }
}