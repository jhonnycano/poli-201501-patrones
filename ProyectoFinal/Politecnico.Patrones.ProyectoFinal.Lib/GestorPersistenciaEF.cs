﻿using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.MV;

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
        public IList<MVCancion> TraerCanciones(int pagina, string filtroNombre, FiltroAlbum filtroAlbum, int? album) {
            var canciones = _ctx.DbSetCancion
                .Where(c => string.IsNullOrEmpty(filtroNombre) || c.Nombre.Contains(filtroNombre)
                            && (filtroAlbum == FiltroAlbum.Todas ||
                                (filtroAlbum == FiltroAlbum.SinAlbum && c.AlbumId == null) ||
                                (filtroAlbum == FiltroAlbum.DelAlbum && c.AlbumId == album)
                                )
                )
                .OrderBy(c => c.Id)
                .Skip(20*pagina)
                .Take(20)
                .Select(c => c).ToList();
            var lista = (from c in canciones select new MVCancion(c)).ToList();
            var result = TraerVotosCanciones(lista);
            result = TraerAlbumesCanciones(result);
            result = TraerInterpretesCanciones(result);
            return result;
        }
        public IList<MVCancion> TraerCancionesInterprete(int interpreteId) {
            var canciones = (from c in _ctx.DbSetCancion
                where _ctx.DbSetCancionInterprete.Any(ai => ai.InterpreteId == interpreteId && ai.CancionId == c.Id)
                select c)
                .ToList();

            var lista = (from c in canciones select new MVCancion(c)).ToList();
            var result = TraerVotosCanciones(lista);
            result = TraerAlbumesCanciones(result);
            result = TraerInterpretesCanciones(result);
            return result;
        }
        public IList<MVCancion> TraerCancionesAlbum(int albumId) {
            var canciones = _ctx.DbSetCancion
                .Where(c => c.AlbumId == albumId)
                .Select(c => c)
                .ToList();

            var lista = (from c in canciones select new MVCancion(c)).ToList();
            var result = DetallarCanciones(lista);
            return result;
        }
        public IList<MVCancion> TraerCancionesMasVotadas(int cantidad) {
            var canciones = from c in _ctx.DbSetCancion
                join a in _ctx.DbSetAlbum on c.AlbumId equals a.Id into j
                from a in j.DefaultIfEmpty()
                join vu in _ctx.DbSetVotableUsuario on c.VotableId equals vu.VotableId
                group new {c, vu} by new
                    {
                        c.Id,
                        c.Nombre,
                        AlbumId = a == null ? (int?) null : a.Id,
                        Album = a == null ? "Sin album" : a.Nombre
                    }
                into g
                select new MVCancion
                    {
                        Id = g.Key.Id,
                        Nombre = g.Key.Nombre,
                        Album = g.Key.Album,
                        AlbumId = g.Key.AlbumId,
                        TotalVotos = g.Count(x => x.vu != null)
                    };

            var masVotadas = from i in canciones
                orderby i.TotalVotos descending
                select i;

            IList<MVCancion> result = masVotadas.Take(cantidad).ToList();
            result = TraerInterpretesCanciones(result);
            return result;
        }
        public IList<MVCancion> DetallarCanciones(IList<MVCancion> canciones) {
            var result = TraerVotosCanciones(canciones);
            result = TraerAlbumesCanciones(result);
            result = TraerInterpretesCanciones(result);
            return result;
        }

        public Album TraerAlbum(int id) {
            return (from a in _ctx.DbSetAlbum
                where a.Id == id
                select a)
                .FirstOrDefault();
        }
        public IList<MVAlbum> TraerAlbumes(int pagina, string filtroNombre) {
            var albumes = _ctx.DbSetAlbum
                .Where(a => string.IsNullOrEmpty(filtroNombre) || a.Nombre.Contains(filtroNombre))
                .OrderBy(a => a.Id)
                .Skip(20*pagina)
                .Take(20);
            var result = TraerVotosAlbumes(albumes);
            return result;
        }
        public IList<MVAlbum> TraerAlbumesInterprete(int interpreteId) {
            var albumes = _ctx.DbSetAlbum
                .Where(a => _ctx.DbSetAlbumInterprete.Any(ai => ai.InterpreteId == interpreteId && ai.AlbumId == a.Id));
            var result = TraerVotosAlbumes(albumes);
            return result;
        }
        public IList<MVAlbumDetallado> DetallarAlbumes(IList<MVAlbum> albumes) {
            albumes = TraerVotosAlbumes(albumes);
            albumes.ToList().ForEach(a => {
                var album = _ctx.DbSetAlbum.FirstOrDefault(al => a.Id == al.Id);
                if (album != null) a.CargarDesde(album);
            });

            var interpretes = (from a in albumes
                join ai in _ctx.DbSetAlbumInterprete on a.Id equals ai.AlbumId
                join i in _ctx.DbSetInterprete on ai.InterpreteId equals i.Id
                select new {Album = a, Interprete = new MVInterprete {Id = i.Id, Nombre = i.Nombre}}).ToList();
            var canciones = (from a in albumes
                join c in _ctx.DbSetCancion on a.Id equals c.AlbumId
                select new {Album = a, Cancion = new MVCancion(c)}).ToList();

            var listaAlbumDetallado = (from a in albumes select new MVAlbumDetallado(a)).ToList();
            foreach (var itm in listaAlbumDetallado) {
                MVAlbumDetallado albumDetallado = itm;
                itm.Interpretes =
                    (from i in interpretes where i.Album.Id == albumDetallado.Id select i.Interprete).ToList();
                MVAlbumDetallado mvAlbumDetallado = itm;
                itm.Canciones = (from c in canciones where c.Album.Id == mvAlbumDetallado.Id select c.Cancion).ToList();
                itm.Canciones = TraerVotosCanciones(itm.Canciones);
            }

            return listaAlbumDetallado.ToList();
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
            object[] paramsInterno =
                (from p in parametros select new SqlParameter {ParameterName = p.Key, Value = p.Value}).ToArray();
            return _ctx.Database.SqlQuery<T>(consulta, paramsInterno);
        }

        private IList<MVCancion> TraerVotosCanciones(IEnumerable<MVCancion> canciones) {
            var grupo = from a in canciones
                join vu in _ctx.DbSetVotableUsuario on a.VotableId equals vu.VotableId into j1
                from vu in j1.DefaultIfEmpty()
                group new {a, vu} by new
                    {
                        a.Id,
                        a.Nombre,
                        a.FchCreacion,
                        a.AlbumId,
                        a.VotableId,
                    }
                into g
                select new MVCancion
                    {
                        Id = g.Key.Id,
                        Nombre = g.Key.Nombre,
                        FchCreacion = g.Key.FchCreacion,
                        AlbumId = g.Key.AlbumId,
                        VotableId = g.Key.VotableId,
                        TotalVotos = g.Count(x => x.vu != null)
                    };
            var lista = grupo.ToList();
            return lista;
        }
        private IList<MVCancion> TraerInterpretesCanciones(IList<MVCancion> canciones) {
            // interpretes de cancion
            var grupoCancion = (from c in canciones
                join ci in _ctx.DbSetCancionInterprete on c.Id equals ci.CancionId
                join i in _ctx.DbSetInterprete on ci.InterpreteId equals i.Id
                select new {Cancion = c, Interprete = i}).ToList();
            foreach (var itm in grupoCancion) {
                if (itm.Cancion.Interpretes == null) itm.Cancion.Interpretes = new List<MVInterprete>();
                itm.Cancion.Interpretes.Add(new MVInterprete(itm.Interprete));
            }

            // interpretes de album
            var grupoAlbum = (from c in canciones
                join ai in _ctx.DbSetAlbumInterprete on c.AlbumId equals ai.AlbumId
                join i in _ctx.DbSetInterprete on ai.InterpreteId equals i.Id
                select new {Cancion = c, Interprete = i}).ToList();
            foreach (var itm in grupoAlbum) {
                if (itm.Cancion.InterpretesAlbum == null) itm.Cancion.InterpretesAlbum = new List<MVInterprete>();
                itm.Cancion.InterpretesAlbum.Add(new MVInterprete(itm.Interprete));
            }

            return canciones;
        }
        private IList<MVCancion> TraerAlbumesCanciones(IList<MVCancion> canciones) {
            foreach (var cancion in canciones) {
                var album = _ctx.DbSetAlbum.FirstOrDefault(a => a.Id == cancion.AlbumId);
                if (album == null) continue;

                cancion.Album = album.Nombre;
            }
            return canciones;
        }
        private IList<MVAlbum> TraerVotosAlbumes(IEnumerable<Album> albumes) {
            var grupo = from a in albumes
                join vu in _ctx.DbSetVotableUsuario on a.VotableId equals vu.VotableId into j1
                from vu in j1.DefaultIfEmpty()
                group new {a, vu} by new
                    {
                        a.Id,
                        a.Nombre,
                        a.AñoLanzamiento,
                        a.FchCreacion,
                        a.VotableId,
                    }
                into g
                select new MVAlbum
                    {
                        Id = g.Key.Id,
                        VotableId = g.Key.VotableId,
                        Nombre = g.Key.Nombre,
                        AñoLanzamiento = g.Key.AñoLanzamiento,
                        FchCreacion = g.Key.FchCreacion,
                        TotalVotos = g.Count(x => x.vu != null)
                    };
            var lista = grupo.ToList();
            return lista;
        }
        private IList<MVAlbum> TraerVotosAlbumes(IList<MVAlbum> albumes) {
            var grupo = (from a in albumes
                join vu in _ctx.DbSetVotableUsuario on a.VotableId equals vu.VotableId into j1
                from vu in j1.DefaultIfEmpty()
                group new {a, vu} by new
                    {
                        a.Id,
                        a.Nombre,
                        a.AñoLanzamiento,
                        a.FchCreacion,
                    }
                into g
                select new MVAlbum
                    {
                        Id = g.Key.Id,
                        TotalVotos = g.Count(x => x.vu != null)
                    }).ToDictionary(itm => itm.Id);
            albumes.ToList().ForEach(a => {
                if (grupo.ContainsKey(a.Id)) a.TotalVotos = grupo[a.Id].TotalVotos;
            });
            return albumes;
        }
    }
}