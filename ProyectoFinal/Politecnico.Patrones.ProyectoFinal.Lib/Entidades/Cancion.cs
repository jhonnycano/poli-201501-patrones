using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Entidades {
    [Table("Cancion")]
    public class Cancion : IElementoVotable {
        [Key]
        public int Id { get; set; }
        public int VotableId { get; set; }
        public string Nombre { get; set; }
        public int? AlbumId { get; set; }
    }
}