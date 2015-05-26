using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.Entidades {
    [Table("Album")]
    public class Album : IElementoVotable {
        [Key]
        public int Id { get; set; }
        public DateTime FchCreacion { get; set; }
        public int VotableId { get; set; }
        public string Nombre { get; set; }
        public int AñoLanzamiento { get; set; }
    }
}