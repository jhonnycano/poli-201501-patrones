using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;
using Politecnico.Patrones.ProyectoFinal.Lib.Reportes;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    internal class FabricaReportes {
        public IReporte TraerReporte(TipoReporte tipoReporte) {
            switch (tipoReporte) {
                case TipoReporte.ListaCanciones:
                    return new ReporteListaCanciones();
                case TipoReporte.ListaInterpretes:
                    return new ReporteListaInterpretes();
                case TipoReporte.ListaAlbumes:
                    return new ReporteListaAlbumes();
                case TipoReporte.ListaCancionesAlbum:
                    return new ReporteListaCancionesAlbum();
                default:
                    return null;
            }
        }
    }
}