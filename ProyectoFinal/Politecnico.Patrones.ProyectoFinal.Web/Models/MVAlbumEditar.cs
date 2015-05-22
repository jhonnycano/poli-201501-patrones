using System.Collections.Generic;
using System.ComponentModel;

namespace Politecnico.Patrones.ProyectoFinal.Web.Models
{
    public class MVAlbumEditar
    {
        public int AlbumId { get; set; }
        [DisplayName("Nombre del álbum")]
        public string AlbumNombre { get; set; }
        public IEnumerable<MVInterprete> ListaInterpretes { get; set; }
    }
}