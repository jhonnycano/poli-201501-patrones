using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Lib.Reportes;

namespace Politecnico.Patrones.ProyectoFinal.Lib.MV {
    public class MVAlbumLista : ReporteConsulta {
        public override object Objeto {
            get { return Items; }
            set { Items = (IList<MVAlbum>) value; }
        }
        public IList<MVAlbum> Items { get; set; }
    }
}