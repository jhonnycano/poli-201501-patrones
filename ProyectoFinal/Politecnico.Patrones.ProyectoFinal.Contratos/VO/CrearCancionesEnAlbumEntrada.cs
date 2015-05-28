using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.VO {
    public class CrearCancionesEnAlbumEntrada {
        public int AlbumId { get; set; }
        public IList<string> Canciones { get; set; }
    }
}