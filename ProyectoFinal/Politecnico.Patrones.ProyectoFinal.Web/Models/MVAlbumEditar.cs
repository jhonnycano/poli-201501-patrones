using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Web.Models
{
    public class MVAlbumEditar
    {
        public int AlbumId { get; set; }
        public string AlbumNombre { get; set; }
        public IEnumerable<MVInterprete> ListaInterpretes { get; set; }
    }
}