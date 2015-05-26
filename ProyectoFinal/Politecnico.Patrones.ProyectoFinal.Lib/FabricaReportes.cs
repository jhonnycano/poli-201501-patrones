using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;
using Politecnico.Patrones.ProyectoFinal.Lib.Reportes;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    internal class FabricaReportes {
        private readonly IGestorPersistencia _gestorPersistencia;
        public FabricaReportes(IGestorPersistencia gestorPersistencia) {
            _gestorPersistencia = gestorPersistencia;
        }
        public IReporte TraerReporte(TipoReporte tipoReporte) {
            switch (tipoReporte) {
                case TipoReporte.ListaCanciones:
                    return new ReporteListaCanciones(_gestorPersistencia);
                case TipoReporte.ListaInterpretes:
                    return new ReporteDetalleInterprete(_gestorPersistencia);
                case TipoReporte.ListaAlbumes:
                    return new ReporteListaAlbumes(_gestorPersistencia);
                case TipoReporte.ListaCancionesAlbum:
                    return new ReporteListaCancionesAlbum(_gestorPersistencia);
                default:
                    return null;
            }
        }
    }
}