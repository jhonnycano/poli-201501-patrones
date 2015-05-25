using System.Data.Entity;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public class ContextoEF : DbContext {
        public ContextoEF() : base(@"principal") {
        }
        public DbSet<Interprete> DbSetInterprete { get; set; }
        public DbSet<Album> DbSetAlbum { get; set; }
        public DbSet<AlbumInterprete> DbSetAlbumInterprete { get; set; }
        public DbSet<Cancion> DbSetCancion { get; set; }
        public DbSet<CancionInterprete> DbSetCancionInterprete { get; set; }
        public DbSet<Votable> DbSetVotable { get; set; }
        public DbSet<VotableUsuario> DbSetVotableUsuario { get; set; }
        public DbSet<Usuario> DbSetUsuario { get; set; }
    }
}