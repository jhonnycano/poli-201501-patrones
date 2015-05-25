using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;

namespace Politecnico.Patrones.ProyectoFinal.Contratos {
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
        IList<Cancion> TraerCanciones(int pagina, string nombre);
        IList<Interprete> TraerInterpretes(int pagina, string nombre);
        IList<Interprete> TraerInterpretesAlbum(int albumId);
        Cancion TraerCancion(int id);
    }
}