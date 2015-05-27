using System;
using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.MV {
    public class MVCancion: ICancion {
        public MVCancion() {
        }
        public MVCancion(ICancion cancion) {
            Id = cancion.Id;
            Nombre = cancion.Nombre;
            VotableId = cancion.VotableId;
        }
        public int Id { get; set; }
        public DateTime FchCreacion { get; set; }
        public string Nombre { get; set; }
        public int VotableId { get; set; }
        public string Album { get; set; }
        public IList<MVInterprete> Interpretes { get; set; }
        public int TotalVotos { get; set; }
    }
}