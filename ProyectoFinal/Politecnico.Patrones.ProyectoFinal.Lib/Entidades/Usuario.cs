using System.ComponentModel.DataAnnotations;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Entidades {
    public class Usuario {
        [Key]
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}