using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;
using Politecnico.Patrones.ProyectoFinal.Lib.MV;

namespace Politecnico.Patrones.ProyectoFinal.Contratos {
    public enum FiltroAlbum { SinAlbum = 0, DelAlbum = 1, Todas = 2 }

    public interface IGestorDominio {
        EditarCancionSalida EditarCancion(EditarCancionEntrada entrada);
        EditarInterpreteSalida EditarInterprete(EditarInterpreteEntrada entrada);
        EditarAlbumSalida EditarAlbum(EditarAlbumEntrada entrada);

        RelacionarInterpretesACancionSalida RelacionarInterpretesACancion(RelacionarInterpretesACancionEntrada entrada);
        RelacionarInterpretesAAlbumSalida RelacionarInterpretesAAlbum(RelacionarInterpretesAAlbumEntrada entrada);

        AsociarCancionYAlbumSalida AsociarCancionYAlbum(AsociarCancionYAlbumEntrada entrada);

        RegistrarVotoCancionesSalida RegistrarVotoCanciones(RegistrarVotoCancionesEntrada entrada);
        RegistrarVotoAlbumesSalida RegistrarVotoAlbumes(RegistrarVotoAlbumesEntrada entrada);

        GenerarReporteSalida GenerarReporte(GenerarReporteEntrada entrada);

        // metodos de consulta
        Album TraerAlbum(int id);
        Interprete TraerInterprete(int id);

        IList<Album> TraerAlbumes(int pagina, string nombre);
        IList<Album> TraerAlbumesInterprete(int interpreteId);
        IList<Cancion> TraerCanciones(int pagina, string nombre, FiltroAlbum filtroAlbum, int? album);
        IList<Cancion> TraerCancionesAlbum(int albumId);
        IList<Cancion> TraerCancionesInterprete(int interpreteId);
        IList<MVCancion> TraerCancionesMasVotadas(int cantidad);
        IList<Interprete> TraerInterpretes(int pagina, string nombre);
        IList<Interprete> TraerInterpretesAlbum(int albumId);
        Cancion TraerCancion(int id);
    }
}