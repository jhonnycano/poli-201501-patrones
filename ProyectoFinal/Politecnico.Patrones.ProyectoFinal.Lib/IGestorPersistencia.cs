using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public interface IGestorPersistencia {
        Usuario TraerUsuario(string correo);
        Usuario TraerUsuario(string correo, string clave);

        Interprete TraerInterprete(int id);
        IList<Interprete> TraerInterpretes(int pagina, string filtroNombre);
        Cancion TraerCancion(int id);
        IList<Cancion> TraerCanciones(int pagina);
        CancionInterprete TraerCancionInterprete(int cancionId, int interpreteId);
        Album TraerAlbum(int id);
        IList<Album> TraerAlbumes(int pagina);
        AlbumInterprete TraerAlbumInterprete(int albumId, int interpreteId);

        VotableUsuario TraerVotableUsuario(int votableId, int usuarioId);

        void Guardar(Interprete interprete);
        void Guardar(Cancion cancion);
        void Guardar(CancionInterprete cancionInterprete);
        void Guardar(Album album);
        void Guardar(AlbumInterprete albumInterprete);
        void Guardar(Votable votable);
        void Guardar(VotableUsuario votableUsuario);
        void Guardar(Usuario usuario);

        void Eliminar(CancionInterprete cancionInterprete);
        void Eliminar(AlbumInterprete albumInterprete);
    }
}