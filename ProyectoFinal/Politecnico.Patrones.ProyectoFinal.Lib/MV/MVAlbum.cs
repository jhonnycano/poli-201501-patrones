using System;
using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Lib.MV {
    public class MVAlbum {
        public int Id { get; set; }
        public DateTime FchCreacion { get; set; }
        public int Nombre { get; set; }
        public int AñoLanzamiento { get; set; }
        public int TotalVotos { get; set; }
    }
}