using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Entidades {
    [Table("Album")]
    public class Album {
        [Key]
        public int Id { get; set; }
        public int Votable { get; set; }
        public string Nombre { get; set; }
        public int InterpreteId { get; set; }
    }
}