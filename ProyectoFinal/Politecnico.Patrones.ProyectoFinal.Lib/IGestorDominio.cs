using Politecnico.Patrones.ProyectoFinal.Lib.VO;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public interface IGestorDominio {
        EditarCancionSalida EditarCancion(EditarCancionEntrada entrada);
        EditarInterpreteSalida EditarInterprete(EditarInterpreteEntrada entrada);
        EditarAlbumSalida EditarAlbum(EditarAlbumEntrada entrada);
        AsociarCancionYAlbumSalida AsociarCancionYAlbum(AsociarCancionYAlbumEntrada entrada);
        RegistrarVotoCancionSalida RegistrarVotoCancion(RegistrarVotoCancionEntrada entrada);
        RegistrarVotoAlbumSalida RegistrarVotoAlbum(RegistrarVotoAlbumEntrada entrada);
        GenerarReporteSalida GenerarReporte(GenerarReporteEntrada entrada);
    }
}