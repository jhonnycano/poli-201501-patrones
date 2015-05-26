using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.VO {
    public class EditarCancionEntrada {
        public int CancionId { get; set; }
        public string Nombre { get; set; }
        public int? AlbumId { get; set; }
    }
}