using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.Entidades {
    [Table("Usuario")]
    public class Usuario {
        [Key]
        public int Id { get; set; }
        public DateTime FchCreacion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}