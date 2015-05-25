using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Newtonsoft.Json.Linq;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Lib.Recursos;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    internal class ImportadorJson {
        private ContextoEF _ctx;
        public bool Importar(ContextoEF context) {
            _ctx = context;
            try {
                var obj = JObject.Parse(Cadenas.seed_json);
                ImportarInterpretes(obj);
                ImportarAlbumes(obj);
                ImportarCanciones(obj);
                ImportarUsuarios(obj);
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
                _ctx.DbSetInterprete.AddOrUpdate(new Interprete {Id = id, Nombre = nombre});
            }
            _ctx.SaveChanges();
        }
        private void ImportarAlbumes(JObject obj) {
            var arr = obj["albumes"] as JArray;
            if (arr == null) return;

            foreach (var token in arr) {
                var id = token.Value<int>("id");
                var nombre = token.Value<string>("nombre");
                var arrInterpretes = token["interpretes"];
                _ctx.DbSetAlbum.AddOrUpdate(new Album {Id = id, Nombre = nombre});
                foreach (var tokenInterprete in arrInterpretes) {
                    var interpreteId = tokenInterprete.Value<int>();
                    var ai =
                        _ctx.DbSetAlbumInterprete.FirstOrDefault(x => x.AlbumId == id && x.InterpreteId == interpreteId) ??
                        new AlbumInterprete {AlbumId = id, InterpreteId = interpreteId};
                    _ctx.DbSetAlbumInterprete.AddOrUpdate(ai);
                }
            }
            _ctx.SaveChanges();
        }
        private void ImportarCanciones(JObject obj) {
            var arr = obj["canciones"] as JArray;
            if (arr == null) return;

            foreach (var token in arr) {
                var id = token.Value<int>("id");
                var nombre = token.Value<string>("nombre");
                var album = token.Value<int?>("album");
                var arrInterpretes = token["interpretes"];
                _ctx.DbSetCancion.AddOrUpdate(new Cancion {Id = id, Nombre = nombre, AlbumId = album});
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
            }
            _ctx.SaveChanges();
        }
        private void ImportarUsuarios(JObject obj) {
        }
    }
}