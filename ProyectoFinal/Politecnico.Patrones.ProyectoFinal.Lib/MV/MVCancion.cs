using System;
using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Lib.MV {
    public class MVCancion {
        public MVCancion() {
        }
        public MVCancion(Cancion cancion) {
            Id = cancion.Id;
            Nombre = cancion.Nombre;
        }
        public int Id { get; set; }
        public DateTime FchCreacion { get; set; }
        public string Nombre { get; set; }
        public string Album { get; set; }
        public IList<MVInterprete> Interpretes { get; set; }
        public int TotalVotos { get; set; }
    }
}