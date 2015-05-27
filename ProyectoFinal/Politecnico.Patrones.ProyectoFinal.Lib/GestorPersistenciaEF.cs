using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Lib.MV;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    internal class GestorPersistenciaEF : IGestorPersistencia {
        private readonly ContextoEF _ctx;
        public GestorPersistenciaEF() {
            _ctx = new ContextoEF();
        }

        public Usuario TraerUsuario(int id) {
            return (from c in _ctx.DbSetUsuario
                where c.Id == id
                select c)
                .FirstOrDefault();
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
        public IList<Interprete> TraerInterpretes(int pagina, string filtroNombre) {
            return _ctx.DbSetInterprete
                .Where(i => string.IsNullOrEmpty(filtroNombre) || i.Nombre.Contains(filtroNombre))
                .OrderBy(i => i.Id)
                .Skip(20*pagina)
                .Take(20)
                .ToList();
        }
        public IList<Interprete> TraerInterpretesAlbum(int albumId) {
            return (from i in _ctx.DbSetInterprete
                join ai in _ctx.DbSetAlbumInterprete on i.Id equals ai.InterpreteId
                where ai.AlbumId == albumId
                select i).ToList();
        }
        public IList<Interprete> TraerInterpretesCancion(int cancionId) {
            return (from i in _ctx.DbSetInterprete
                join ai in _ctx.DbSetCancionInterprete on i.Id equals ai.InterpreteId
                    where ai.CancionId == cancionId
                    select i).ToList();
        }
        public Cancion TraerCancion(int id) {
            return (from c in _ctx.DbSetCancion
                where c.Id == id
                select c)
                .FirstOrDefault();
        }
        public IList<Cancion> TraerCanciones(int pagina, string filtroNombre, FiltroAlbum filtroAlbum, int? album) {
            return _ctx.DbSetCancion
                .Where(c => string.IsNullOrEmpty(filtroNombre) || c.Nombre.Contains(filtroNombre)
                            && (filtroAlbum == FiltroAlbum.Todas ||
                                (filtroAlbum == FiltroAlbum.SinAlbum && c.AlbumId == null) ||
                                (filtroAlbum == FiltroAlbum.DelAlbum && c.AlbumId == album)
                                )
                )
                .OrderBy(c => c.Id)
                .Skip(20*pagina)
                .Take(20)
                .ToList();
        }
        public IList<Cancion> TraerCancionesInterprete(int interpreteId) {
            return _ctx.DbSetCancion
                .Where(c => _ctx.DbSetCancionInterprete.Any(ai => ai.InterpreteId == interpreteId && ai.CancionId == c.Id))
                .ToList();
        }
        public IList<Cancion> TraerCancionesAlbum(int albumId) {
            return _ctx.DbSetCancion
                .Where(c => c.AlbumId == albumId)
                .ToList();
        }
        public IList<MVCancion> TraerCancionesMasVotadas(int cantidad) {
            var q = from c in _ctx.DbSetCancion
                join a in _ctx.DbSetAlbum on c.AlbumId equals a.Id into j
                from a in j.DefaultIfEmpty()
                join vu in _ctx.DbSetVotableUsuario on c.VotableId equals vu.VotableId
                group new {c, vu} by new {c.Id, c.Nombre, Album = a == null ? "Sin album": a.Nombre}
                into g
                select new MVCancion
                    {
                        Id = g.Key.Id,
                        Nombre = g.Key.Nombre,
                        Album = g.Key.Album,
                        TotalVotos = g.Count()
                    };
            var q2 = from i in q
                orderby i.TotalVotos descending
                select i;

            return q2.Take(cantidad).ToList();
        }
        public Album TraerAlbum(int id) {
            return (from a in _ctx.DbSetAlbum
                where a.Id == id
                select a)
                .FirstOrDefault();
        }
        public IList<Album> TraerAlbumes(int pagina, string filtroNombre) {
            return _ctx.DbSetAlbum
                .Where(a => string.IsNullOrEmpty(filtroNombre) || a.Nombre.Contains(filtroNombre))
                .OrderBy(a => a.Id)
                .Skip(20*pagina)
                .Take(20)
                .ToList();
        }
        public IList<Album> TraerAlbumesInterprete(int interpreteId) {
            return _ctx.DbSetAlbum
                .Where(a => _ctx.DbSetAlbumInterprete.Any(ai => ai.InterpreteId == interpreteId && ai.AlbumId == a.Id))
                .ToList();
        }
        public CancionInterprete TraerCancionInterprete(int cancionId, int interpreteId) {
            return (from c in _ctx.DbSetCancionInterprete
                where c.CancionId == cancionId && c.InterpreteId == interpreteId
                select c)
                .FirstOrDefault() ?? new CancionInterprete
                    {
                        CancionId = cancionId,
                        InterpreteId = interpreteId
                    };
        }
        public AlbumInterprete TraerAlbumInterprete(int albumId, int interpreteId) {
            return (from c in _ctx.DbSetAlbumInterprete
                where c.AlbumId == albumId && c.InterpreteId == interpreteId
                select c)
                .FirstOrDefault() ?? new AlbumInterprete
                    {
                        AlbumId = albumId,
                        InterpreteId = interpreteId
                    };
        }
        public VotableUsuario TraerVotableUsuario(int votableId, int usuarioId) {
            return (from vu in _ctx.DbSetVotableUsuario
                where vu.VotableId == votableId && vu.UsuarioId == usuarioId
                select vu)
                .FirstOrDefault();
        }

        public void Guardar(Interprete entidad) {
            _ctx.DbSetInterprete.AddOrUpdate(entidad);
            _ctx.SaveChanges();
        }
        public void Guardar(Album album) {
            _ctx.DbSetAlbum.AddOrUpdate(album);
            _ctx.SaveChanges();
        }
        public void Guardar(AlbumInterprete albumInterprete) {
            _ctx.DbSetAlbumInterprete.AddOrUpdate(albumInterprete);
            _ctx.SaveChanges();
        }
        public void Guardar(Cancion entidad) {
            _ctx.DbSetCancion.AddOrUpdate(entidad);
            _ctx.SaveChanges();
        }
        public void Guardar(CancionInterprete cancionInterprete) {
            _ctx.DbSetCancionInterprete.AddOrUpdate(cancionInterprete);
            _ctx.SaveChanges();
        }
        public void Guardar(Votable votable) {
            _ctx.DbSetVotable.AddOrUpdate(votable);
            _ctx.SaveChanges();
        }
        public void Guardar(VotableUsuario votableUsuario) {
            _ctx.DbSetVotableUsuario.AddOrUpdate(votableUsuario);
            _ctx.SaveChanges();
        }
        public void Guardar(Usuario usuario) {
            _ctx.DbSetUsuario.AddOrUpdate(usuario);
            _ctx.SaveChanges();
        }

        public void EliminarCancionInterprete(int interprete, int cancion) {
            var cancionInterprete = TraerCancionInterprete(cancion, interprete);
            if (cancionInterprete == null || cancionInterprete.Id <= 0) return;

            _ctx.DbSetCancionInterprete.Remove(cancionInterprete);
            _ctx.SaveChanges();
        }
        public void EliminarCancionInterprete(int cancion) {
            foreach (var itm in _ctx.Set<CancionInterprete>().Where(itm => itm.CancionId == cancion)) {
                _ctx.Entry(itm).State = EntityState.Deleted;
            }
            _ctx.SaveChanges();
        }
        public void EliminarAlbumInterprete(int interprete, int album) {
            var albumInterprete = TraerAlbumInterprete(album, interprete);
            if (albumInterprete == null || albumInterprete.Id <= 0) return;

            _ctx.DbSetAlbumInterprete.Remove(albumInterprete);
            _ctx.SaveChanges();
        }
        public void EliminarVotableUsuario(int votable, int usuario) {
            var votableUsuario = TraerVotableUsuario(votable, usuario);
            if (votableUsuario == null || votableUsuario.Id <= 0) return;

            _ctx.DbSetVotableUsuario.Remove(votableUsuario);
            _ctx.SaveChanges();
        }
        public IEnumerable<T> TraerConsulta<T>(string consulta, IDictionary<string, object> parametros) {
            object[] paramsInterno = (from p in parametros select new SqlParameter {ParameterName = p.Key, Value = p.Value}).ToArray();
            return _ctx.Database.SqlQuery<T>(consulta, paramsInterno);
        }
    }
}