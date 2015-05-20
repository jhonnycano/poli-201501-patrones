using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public interface IGestorPersistencia {
        Usuario TraerUsuario(string correo);
        Usuario TraerUsuario(string correo, string clave);

        Interprete TraerInterprete(int id);
        Cancion TraerCancion(int id);
        CancionInterprete TraerCancionInterprete(int cancionId, int interpreteId);
        Album TraerAlbum(int id);
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