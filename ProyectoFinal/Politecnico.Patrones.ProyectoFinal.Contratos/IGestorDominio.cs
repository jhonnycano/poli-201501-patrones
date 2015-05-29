using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.MV;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;

namespace Politecnico.Patrones.ProyectoFinal.Contratos {
    public enum FiltroAlbum { SinAlbum = 0, DelAlbum = 1, Todas = 2 }

    public interface IGestorDominio {
        EditarCancionSalida EditarCancion(EditarCancionEntrada entrada);
        EditarInterpreteSalida EditarInterprete(EditarInterpreteEntrada entrada);
        EditarAlbumSalida EditarAlbum(EditarAlbumEntrada entrada);

        RelacionarInterpretesACancionSalida RelacionarInterpretesACancion(RelacionarInterpretesACancionEntrada entrada);
        RelacionarInterpretesAAlbumSalida RelacionarInterpretesAAlbum(RelacionarInterpretesAAlbumEntrada entrada);

        AsociarCancionYAlbumSalida AsociarCancionYAlbum(AsociarCancionYAlbumEntrada entrada);
        CrearCancionesEnAlbumSalida CrearCancionesEnAlbum(CrearCancionesEnAlbumEntrada entrada);

        RegistrarVotoCancionesSalida RegistrarVotoCanciones(RegistrarVotoCancionesEntrada entrada);
        RegistrarVotoAlbumesSalida RegistrarVotoAlbumes(RegistrarVotoAlbumesEntrada entrada);

        GenerarReporteSalida GenerarReporte(GenerarReporteEntrada entrada);

        // metodos de consulta
        Album TraerAlbum(int id);
        MVCancion TraerCancion(int id);
        Interprete TraerInterprete(int id);

        IList<MVAlbum> TraerAlbumes(int pagina, string nombre, int? interprete);
        IList<MVAlbum> TraerAlbumesInterprete(int interpreteId);
        IList<MVAlbumDetallado> DetallarAlbumes(IList<MVAlbum> albumes);
        IList<MVCancion> DetallarCanciones(IList<MVCancion> canciones);
        IList<MVCancion> TraerCanciones(int pagina, string nombre, FiltroAlbum filtroAlbum, int? album);
        IList<MVCancion> TraerCancionesAlbum(int albumId);
        IList<MVCancion> TraerCancionesInterprete(int interpreteId);
        IList<MVCancion> TraerCancionesMasVotadas(int cantidad);
        IList<Interprete> TraerInterpretes(int pagina, string nombre);
        IList<Interprete> TraerInterpretesAlbum(int albumId);
    }
}