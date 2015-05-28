using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.MV {
    public class MVAlbum {
        public MVAlbum() {
        }
        public MVAlbum(Album album) {
            Id = album.Id;
            Nombre = album.Nombre;
        }
        public int Id { get; set; }
        [DisplayName("Fecha de Creación")]
        public DateTime FchCreacion { get; set; }
        [DisplayName("Nombre del álbum")]
        public string Nombre { get; set; }
        [DisplayName("Año de lanzamiento")]
        [Range(typeof (int), "1900", "2100", ErrorMessage = "{0} debe estar entre {1} y {2}")]
        public int AñoLanzamiento { get; set; }
        [DisplayName("Votos")]
        public int TotalVotos { get; set; }
    }
}