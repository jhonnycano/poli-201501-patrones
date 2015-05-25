using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.Entidades {
    [Table("CancionInterprete")]
    public class CancionInterprete {
        [Key]
        public int Id { get; set; }
        public int CancionId { get; set; }
        public int InterpreteId { get; set; }
    }
}