using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Lib.MV;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.MV {
    public class MVCancionLista {
        public bool MostrarAlbum { get; set; }
        public IList<MVCancion> Canciones { get; set; }
    }
}