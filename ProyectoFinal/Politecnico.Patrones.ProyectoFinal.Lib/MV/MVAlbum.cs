using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Politecnico.Patrones.ProyectoFinal.Lib.MV {
    public class MVAlbum {
        public int Id { get; set; }
        [DisplayName("Fecha de Creación")]
        public DateTime FchCreacion { get; set; }
        [DisplayName("Nombre del álbum")]
        public string Nombre { get; set; }
        [DisplayName("Año de lanzamiento")]
        [Range(typeof(int), "1900", "2100", ErrorMessage = "{0} debe estar entre {1} y {2}")]
        public int AñoLanzamiento { get; set; }
        [DisplayName("Total de votos")]
        public int TotalVotos { get; internal set; }
    }
}