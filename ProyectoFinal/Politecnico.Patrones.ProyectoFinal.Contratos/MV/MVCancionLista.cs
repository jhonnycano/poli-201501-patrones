using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.MV {
    public class MVCancionLista {
        public bool MostrarAlbum { get; set; }
        public IList<MVCancion> Canciones { get; set; }
        public bool MostrarCabecera { get; set; }
        public MVCancionLista() {
            MostrarCabecera = true;
        }
    }
}