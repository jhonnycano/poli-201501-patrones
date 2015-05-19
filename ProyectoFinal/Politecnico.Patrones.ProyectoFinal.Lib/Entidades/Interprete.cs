using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Entidades {
    [Table("Interprete")]
    public class Interprete {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}