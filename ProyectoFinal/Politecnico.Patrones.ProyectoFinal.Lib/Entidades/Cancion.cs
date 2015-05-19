using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Entidades {
    [Table("Cancion")]
    public class Cancion {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int InterpreteId { get; set; }
        public int? AlbumId { get; set; }
        public int Votable { get; set; }
    }
}