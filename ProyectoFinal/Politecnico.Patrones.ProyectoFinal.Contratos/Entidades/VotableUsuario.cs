using System.ComponentModel.DataAnnotations.Schema;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.Entidades {
    [Table("VotableUsuario")]
    public class VotableUsuario {
        public int Id { get; set; }
        public int VotableId { get; set; }
        public int UsuarioId { get; set; }
    }
}