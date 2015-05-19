using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public interface IGestorPersistencia {
        Cancion TraerCancion(int id);
        Interprete TraerInterprete(int id);
        Album TraerAlbum(int id);

        void Guardar(Cancion cancion);
        void Guardar(Interprete interprete);
        void Guardar(Album album);
    }
}