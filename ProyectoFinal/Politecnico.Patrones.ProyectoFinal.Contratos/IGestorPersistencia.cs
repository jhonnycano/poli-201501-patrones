using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.MV;

namespace Politecnico.Patrones.ProyectoFinal.Contratos {
    public interface IGestorPersistencia {
        Usuario TraerUsuario(int id);
        Usuario TraerUsuario(string correo);
        Usuario TraerUsuario(string correo, string clave);

        Interprete TraerInterprete(int id);
        IList<Interprete> TraerInterpretes(int pagina, string filtroNombre);
        IList<Interprete> TraerInterpretesAlbum(int albumId);
        IList<Interprete> TraerInterpretesCancion(int cancionId);

        Cancion TraerCancion(int id);
        IList<MVCancion> TraerCanciones(int pagina, string filtroNombre, FiltroAlbum filtroAlbum, int? album);
        IList<MVCancion> TraerCancionesInterprete(int interpreteId);
        IList<MVCancion> TraerCancionesAlbum(int albumId);
        IList<MVCancion> TraerCancionesMasVotadas(int cantidad);
        IList<MVCancion> DetallarCanciones(IList<MVCancion> canciones);

        Album TraerAlbum(int id);
        IList<MVAlbum> TraerAlbumes(int pagina, string filtroNombre);
        IList<MVAlbum> TraerAlbumesInterprete(int interpreteId);
        IList<MVAlbumDetallado> DetallarAlbumes(IList<MVAlbum> albumes);

        CancionInterprete TraerCancionInterprete(int cancionId, int interpreteId);
        AlbumInterprete TraerAlbumInterprete(int albumId, int interpreteId);

        VotableUsuario TraerVotableUsuario(int votableId, int usuarioId);

        void Guardar(Interprete entidad);
        void Guardar(Cancion entidad);
        void Guardar(CancionInterprete cancionInterprete);
        void Guardar(Album album);
        void Guardar(AlbumInterprete albumInterprete);
        void Guardar(Votable votable);
        void Guardar(VotableUsuario votableUsuario);
        void Guardar(Usuario usuario);

        void EliminarCancionInterprete(int interprete, int cancion);
        void EliminarCancionInterprete(int cancion);
        void EliminarAlbumInterprete(int interprete, int album);
        void EliminarVotableUsuario(int votable, int usuario);
        IEnumerable<T> TraerConsulta<T>(string consulta, IDictionary<string, object> parametros);
    }
}