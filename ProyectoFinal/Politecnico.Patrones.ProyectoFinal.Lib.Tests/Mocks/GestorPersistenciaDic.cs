using System;
using System.Collections.Generic;
using System.Linq;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Tests.Mocks {
    internal class GestorPersistenciaDic : IGestorPersistencia {
        private readonly IDictionary<int, Interprete> _dicInterprete;
        private readonly IDictionary<int, Album> _dicAlbum;
        private readonly IDictionary<int, AlbumInterprete> _dicAlbumInterprete;
        private readonly IDictionary<int, Cancion> _dicCancion;

        public GestorPersistenciaDic() {
            var listaInterprete = new List<Interprete>
                {
                    new Interprete {Id = 9001, Nombre = "Jhonny Cano"},
                    new Interprete {Id = 9002, Nombre = "Jhomar Cano"},
                };
            var listaAlbum = new List<Album>
                {
                    new Album {Id = 10001, Nombre = "Por que", VotableId = 12001}
                };
            var listaCancion = new List<Cancion>
                {
                    new Cancion {Id = 11001, Nombre = "Con los brazos abiertos", VotableId = 12002, AlbumId = 10001},
                    new Cancion {Id = 11002, Nombre = "Quiera Dios que nazcas", VotableId = 12003, AlbumId = 10001},
                    new Cancion {Id = 11003, Nombre = "Un elefante se balanceaba", VotableId = 12003},
                };
            var listaAlbumInterprete = new List<AlbumInterprete>
                {
                    new AlbumInterprete {Id = 13001, AlbumId = 10001, InterpreteId = 9001}
                };

            _dicInterprete = listaInterprete.ToDictionary(i => i.Id, i => i);
            _dicAlbum = listaAlbum.ToDictionary(i => i.Id, i => i);
            _dicCancion = listaCancion.ToDictionary(i => i.Id, i => i);
            _dicAlbumInterprete = listaAlbumInterprete.ToDictionary(i => i.Id, i => i);
        }

        public Usuario TraerUsuario(int id) {
            throw new NotImplementedException();
        }
        public Usuario TraerUsuario(string correo) {
            throw new NotImplementedException();
        }
        public Usuario TraerUsuario(string correo, string clave) {
            throw new NotImplementedException();
        }
        public Interprete TraerInterprete(int id) {
            return BuscarEnDic(_dicInterprete, id);
        }
        public IList<Interprete> TraerInterpretes(int pagina, string filtroNombre) {
            return _dicInterprete.Values.ToList();
        }
        public IList<Interprete> TraerInterpretesAlbum(int albumId) {
            return
                _dicInterprete.Values.Where(i => _dicAlbumInterprete.Values.Any(ai => ai.InterpreteId == i.Id)).ToList();
        }
        public IList<Interprete> TraerInterpretesCancion(int cancionId) {
            throw new NotImplementedException();
        }
        public Cancion TraerCancion(int id) {
            return BuscarEnDic(_dicCancion, id);
        }
        public IList<Cancion> TraerCanciones(int pagina, string filtroNombre) {
            return _dicCancion.Values.ToList();
        }
        public Album TraerAlbum(int id) {
            return BuscarEnDic(_dicAlbum, id);
        }
        public IList<Album> TraerAlbumes(int pagina, string filtroNombre) {
            return _dicAlbum.Values.ToList();
        }
        public CancionInterprete TraerCancionInterprete(int cancionId, int interpreteId) {
            throw new NotImplementedException();
            //return _dicCancionInterprete.Values.FirstOrDefault(ci => ci.CancionId == cancionId && ci.InterpreteId == interpreteId);
        }
        public AlbumInterprete TraerAlbumInterprete(int albumId, int interpreteId) {
            return
                _dicAlbumInterprete.Values.FirstOrDefault(ci => ci.AlbumId == albumId && ci.InterpreteId == interpreteId);
        }
        public VotableUsuario TraerVotableUsuario(int votableId, int usuarioId) {
            throw new NotImplementedException();
        }
        public void Guardar(Interprete entidad) {
            if (!_dicInterprete.ContainsKey(entidad.Id)) {
                var id = _dicInterprete.Values.Max(itm => itm.Id);
                entidad.Id = ++id;
            }
            _dicInterprete[entidad.Id] = entidad;
        }
        public void Guardar(Cancion entidad) {
            if (!_dicCancion.ContainsKey(entidad.Id)) {
                var id = _dicInterprete.Values.Max(itm => itm.Id);
                entidad.Id = ++id;
            }
            _dicCancion[entidad.Id] = entidad;
        }
        public void Guardar(CancionInterprete entidad) {
            throw new NotImplementedException();
        }
        public void Guardar(Album entidad) {
            if (!_dicAlbum.ContainsKey(entidad.Id)) {
                var id = _dicInterprete.Values.Max(itm => itm.Id);
                entidad.Id = ++id;
            }
            _dicAlbum[entidad.Id] = entidad;
        }
        public void Guardar(AlbumInterprete entidad) {
            throw new NotImplementedException();
        }
        public void Guardar(Votable entidad) {
            throw new NotImplementedException();
        }
        public void Guardar(VotableUsuario entidad) {
            throw new NotImplementedException();
        }
        public void Guardar(Usuario entidad) {
            throw new NotImplementedException();
        }
        public void EliminarCancionInterprete(int interprete, int cancion) {
            throw new NotImplementedException();
        }
        public void EliminarCancionInterprete(int cancion) {
            throw new NotImplementedException();
        }
        public void EliminarAlbumInterprete(int interprete, int album) {
            throw new NotImplementedException();
        }
        public void EliminarVotableUsuario(int votable, int usuario) {
            throw new NotImplementedException();
        }
        private T BuscarEnDic<T>(IDictionary<int, T> dic, int id) {
            if (!dic.ContainsKey(id)) return default(T);
            return dic[id];
        }
    }
}