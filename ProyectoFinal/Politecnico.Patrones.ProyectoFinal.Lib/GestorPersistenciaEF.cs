using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public class GestorPersistenciaEF: DbContext, IGestorPersistencia {
        public DbSet<Interprete> DbSetInterprete { get; set; }
        public DbSet<Cancion> DbSetCancion { get; set; }
        public DbSet<Album> DbSetAlbum { get; set; }

        public GestorPersistenciaEF(): base(@"principal") {}

        public Cancion TraerCancion(int id) {
            return (from c in DbSetCancion where c.Id == id select c).First();
        }
        public Interprete TraerInterprete(int id) {
            return (from c in DbSetInterprete where c.Id == id select c).First();
        }
        public Album TraerAlbum(int id) {
            return (from c in DbSetAlbum where c.Id == id select c).First();
        }
        public void Guardar(Cancion cancion) {
            DbSetCancion.AddOrUpdate(cancion);
        }
        public void Guardar(Interprete interprete) {
            DbSetInterprete.AddOrUpdate(interprete);
            SaveChanges();
        }
        public void Guardar(Album album) {
            DbSetAlbum.AddOrUpdate(album);
        }
    }
}