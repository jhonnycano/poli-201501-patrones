using Politecnico.Patrones.ProyectoFinal.Lib.VO;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public interface IGestorDominio {
        EditarCancionSalida EditarCancion(EditarCancionEntrada entrada);
        EditarInterpreteSalida EditarInterprete(EditarInterpreteEntrada entrada);
        EditarAlbumSalida EditarAlbum(EditarAlbumEntrada entrada);

        RelacionarInterpretesYCancionesSalida RelacionarInterpretesYCanciones(RelacionarInterpretesYCancionesEntrada entrada);
        RelacionarInterpretesYAlbumesSalida RelacionarInterpretesYAlbumes(RelacionarInterpretesYAlbumesEntrada entrada);

        AsociarCancionYAlbumSalida AsociarCancionYAlbum(AsociarCancionYAlbumEntrada entrada);

        RegistrarVotoCancionesSalida RegistrarVotoCanciones(RegistrarVotoCancionesEntrada entrada);
        RegistrarVotoAlbumesSalida RegistrarVotoAlbumes(RegistrarVotoAlbumesEntrada entrada);

        GenerarReporteSalida GenerarReporte(GenerarReporteEntrada entrada);
    }
}