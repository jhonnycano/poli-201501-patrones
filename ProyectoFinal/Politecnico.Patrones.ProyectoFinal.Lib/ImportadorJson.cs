using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Newtonsoft.Json.Linq;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Lib.Recursos;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    internal class ImportadorJson {
        private ContextoEF _ctx;
        private DateTime _fch;
        public bool Importar(ContextoEF context) {
            _ctx = context;
            _fch = DateTime.Now;
            try {
                var obj = JObject.Parse(Cadenas.seed_json);
                ImportarInterpretes(obj);
                ImportarAlbumes(obj);
                ImportarCanciones(obj);
                ImportarUsuarios(obj);
                ImportarVotos(obj);
            } catch (Exception) {
                return false;
            }
            return true;
        }
        private void ImportarInterpretes(JObject obj) {
            var arr = obj["interpretes"] as JArray;
            if (arr == null) return;

            foreach (var token in arr) {
                var id = token.Value<int>("id");
                var nombre = token.Value<string>("nombre");
                _ctx.DbSetInterprete.AddOrUpdate(new Interprete {Id = id, Nombre = nombre, FchCreacion = _fch});
            }
            _ctx.SaveChanges();
        }
        private void ImportarAlbumes(JObject obj) {
            var arr = obj["albumes"] as JArray;
            if (arr == null) return;

            foreach (var token in arr) {
                var id = token.Value<int>("id");
                var nombre = token.Value<string>("nombre");
                var añoLanzamiento = token.Value<int>("añoLanzamiento");
                var arrInterpretes = token["interpretes"];
                var votableId = _ctx.DbSetVotable.Select(v => v.Id).DefaultIfEmpty().Max();
                _ctx.DbSetAlbum.AddOrUpdate(new Album
                    {
                        Id = id,
                        FchCreacion = _fch,
                        Nombre = nombre,
                        VotableId = ++votableId,
                        AñoLanzamiento = añoLanzamiento,
                    });
                _ctx.DbSetVotable.Add(new Votable {Id = votableId});
                foreach (var tokenInterprete in arrInterpretes) {
                    var interpreteId = tokenInterprete.Value<int>();
                    var ai =
                        _ctx.DbSetAlbumInterprete.FirstOrDefault(x => x.AlbumId == id && x.InterpreteId == interpreteId) ??
                        new AlbumInterprete {AlbumId = id, InterpreteId = interpreteId};
                    _ctx.DbSetAlbumInterprete.AddOrUpdate(ai);
                }
                _ctx.SaveChanges();
            }
        }
        private void ImportarCanciones(JObject obj) {
            var arr = obj["canciones"] as JArray;
            if (arr == null) return;

            foreach (var token in arr) {
                var id = token.Value<int>("id");
                var nombre = token.Value<string>("nombre");
                var album = token.Value<int?>("album");
                var arrInterpretes = token["interpretes"];
                var votableId = _ctx.DbSetVotable.Select(v => v.Id).DefaultIfEmpty().Max();
                _ctx.DbSetCancion.AddOrUpdate(new Cancion
                    {
                        Id = id,
                        FchCreacion = _fch,
                        Nombre = nombre,
                        AlbumId = album,
                        VotableId = ++votableId
                    });
                _ctx.DbSetVotable.Add(new Votable {Id = votableId});
                if (arrInterpretes != null) {
                    foreach (var tokenInterprete in arrInterpretes) {
                        var interpreteId = tokenInterprete.Value<int>();
                        var ci =
                            _ctx.DbSetCancionInterprete.FirstOrDefault(
                                x => x.CancionId == id && x.InterpreteId == interpreteId) ??
                            new CancionInterprete {CancionId = id, InterpreteId = interpreteId};
                        _ctx.DbSetCancionInterprete.AddOrUpdate(ci);
                    }
                }
                _ctx.SaveChanges();
            }
        }
        private void ImportarUsuarios(JObject obj)
        {
            var arr = obj["usuarios"] as JArray;
            if (arr == null) return;

            foreach (var token in arr)
            {
                var id = token.Value<int>("id");
                var nombre = token.Value<string>("nombre");
                var correo = token.Value<string>("correo");
                var clave = token.Value<string>("clave");
                _ctx.DbSetUsuario.AddOrUpdate(new Usuario
                {
                    Id = id,
                    FchCreacion = _fch,
                    Nombre = nombre,
                    Correo = correo,
                    Clave = clave
                });
            }
            _ctx.SaveChanges();
        }
        private void ImportarVotos(JObject obj)
        {
            var arr = obj["votos"] as JArray;
            if (arr == null) return;

            foreach (var token in arr) {
                var usuarioId = token.Value<int>("usuario");
                var cancionId = token.Value<int?>("cancion");
                var albumId = token.Value<int?>("album");

                if (cancionId != null) {
                    var cancion = _ctx.DbSetCancion.FirstOrDefault(c => c.Id == cancionId);
                    if (cancion != null) {
                        _ctx.DbSetVotableUsuario.Add(new VotableUsuario
                            {
                                UsuarioId = usuarioId,
                                VotableId = cancion.VotableId,
                                FchCreacion = _fch
                            });
                    }
                } else if (albumId != null) {
                    var album = _ctx.DbSetAlbum.FirstOrDefault(c => c.Id == albumId);
                    if (album != null)
                    {
                        _ctx.DbSetVotableUsuario.Add(new VotableUsuario
                        {
                            UsuarioId = usuarioId,
                            VotableId = album.VotableId,
                            FchCreacion = _fch
                        });
                    }
                    
                }
            }
            _ctx.SaveChanges();
        }
    }
}