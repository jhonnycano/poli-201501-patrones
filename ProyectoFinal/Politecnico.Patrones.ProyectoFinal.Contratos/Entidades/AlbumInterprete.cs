using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.Entidades {
    [Table("AlbumInterprete")]
    public class AlbumInterprete {
        [Key]
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int InterpreteId { get; set; }
    }
}