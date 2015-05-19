using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Entidades {
    [Table("Usuario")]
    public class Usuario {
        [Key]
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}