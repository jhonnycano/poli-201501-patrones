﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.Entidades {
    [Table("Votable")]
    public class Votable {
        [Key]
        public int Id { get; set; }
    }
}