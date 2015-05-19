using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public interface IGestorPersistencia {
        Cancion TraerCancion(int id);
        Interprete TraerInterprete(int id);
        Album TraerAlbum(int id);
        VotableUsuario TraerVotableUsuario(int votableId, int usuarioId);

        void Guardar(Cancion cancion);
        void Guardar(Interprete interprete);
        void Guardar(Album album);
        void Guardar(Votable votable);
        void Guardar(VotableUsuario votableUsuario);
        void Guardar(Usuario usuario);
    }
}