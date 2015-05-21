using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public class GestorPersistenciaEF : DbContext, IGestorPersistencia {
        private readonly ContextoEF _ctx;
        public GestorPersistenciaEF() : base(@"principal") {
            _ctx = new ContextoEF();
        }

        public Usuario TraerUsuario(string correo) {
            return (from c in _ctx.DbSetUsuario
                where c.Correo == correo
                select c)
                .FirstOrDefault();
        }
        public Usuario TraerUsuario(string correo, string clave) {
            return (from c in _ctx.DbSetUsuario
                where c.Correo == correo && c.Clave == clave
                select c)
                .FirstOrDefault();
        }
        public Interprete TraerInterprete(int id) {
            return (from i in _ctx.DbSetInterprete
                where i.Id == id
                select i)
                .FirstOrDefault();
        }
        public IList<Interprete> TraerInterpretes(int pagina) {
            return _ctx.DbSetInterprete.Skip(20 * pagina).Take(20).ToList();
        }
        public Cancion TraerCancion(int id)
        {
            return (from c in _ctx.DbSetCancion
                where c.Id == id
                select c)
                .FirstOrDefault();
        }
        public CancionInterprete TraerCancionInterprete(int cancionId, int interpreteId) {
            return (from c in _ctx.DbSetCancionInterprete
                where c.CancionId == cancionId && c.InterpreteId == interpreteId
                select c)
                .FirstOrDefault();
        }
        public Album TraerAlbum(int id) {
            return (from a in _ctx.DbSetAlbum
                where a.Id == id
                select a)
                .FirstOrDefault();
        }
        public AlbumInterprete TraerAlbumInterprete(int albumId, int interpreteId) {
            return (from c in _ctx.DbSetAlbumInterprete
                    where c.AlbumId == albumId && c.InterpreteId == interpreteId
                    select c)
                .FirstOrDefault();
        }
        public VotableUsuario TraerVotableUsuario(int votableId, int usuarioId) {
            return (from vu in _ctx.DbSetVotableUsuario
                where vu.VotableId == votableId && vu.UsuarioId == usuarioId
                select vu)
                .FirstOrDefault();
        }

        public void Guardar(Interprete interprete) {
            _ctx.DbSetInterprete.AddOrUpdate(interprete);
            SaveChanges();
        }
        public void Guardar(Album album) {
            _ctx.DbSetAlbum.AddOrUpdate(album);
            SaveChanges();
        }
        public void Guardar(AlbumInterprete albumInterprete) {
            _ctx.DbSetAlbumInterprete.AddOrUpdate(albumInterprete);
            SaveChanges();
        }
        public void Guardar(Cancion cancion) {
            _ctx.DbSetCancion.AddOrUpdate(cancion);
            SaveChanges();
        }
        public void Guardar(CancionInterprete cancionInterprete) {
            _ctx.DbSetCancionInterprete.AddOrUpdate(cancionInterprete);
            SaveChanges();
        }
        public void Guardar(Votable votable) {
            _ctx.DbSetVotable.AddOrUpdate(votable);
            SaveChanges();
        }
        public void Guardar(VotableUsuario votableUsuario) {
            _ctx.DbSetVotableUsuario.AddOrUpdate(votableUsuario);
            SaveChanges();
        }
        public void Guardar(Usuario usuario) {
            _ctx.DbSetUsuario.AddOrUpdate(usuario);
            SaveChanges();
        }

        public void Eliminar(CancionInterprete cancionInterprete) {
            _ctx.DbSetCancionInterprete.Remove(cancionInterprete);
            SaveChanges();
        }
        public void Eliminar(AlbumInterprete albumInterprete) {
            _ctx.DbSetAlbumInterprete.Remove(albumInterprete);
            SaveChanges();
        }
    }
}