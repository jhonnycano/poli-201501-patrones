using System;
using System.Collections.Generic;
using System.Linq;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.MV;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;
using Politecnico.Patrones.ProyectoFinal.Lib.Recursos;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    internal class GestorDominio : IGestorDominio {
        private readonly IGestorPersistencia _gestorPersistencia;
        public GestorDominio(IGestorPersistencia gestorPersistencia) {
            _gestorPersistencia = gestorPersistencia;
        }
        public EditarInterpreteSalida EditarInterprete(EditarInterpreteEntrada entrada) {
            var salida = new EditarInterpreteSalida();

            if (string.IsNullOrEmpty(entrada.Nombre))
                return SalidaBase.Fallo(salida, Cadenas.interprete_falta_nombre);

            Interprete interprete;
            if (entrada.InterpreteId > 0) {
                interprete = _gestorPersistencia.TraerInterprete(entrada.InterpreteId);
                if (interprete == null) {
                    return SalidaBase.Fallo(salida,
                        string.Format(Cadenas.interprete_id_no_encontrado, entrada.InterpreteId));
                }
                
                interprete.Nombre = entrada.Nombre;
            } else {
                interprete = new Interprete
                    {
                        Nombre = entrada.Nombre,
                        FchCreacion = DateTime.Now,
                    };
            }
            _gestorPersistencia.Guardar(interprete);
            salida.Interprete = interprete;

            return SalidaBase.Exito(salida);
        }
        public EditarAlbumSalida EditarAlbum(EditarAlbumEntrada entrada) {
            var salida = new EditarAlbumSalida();

            if (string.IsNullOrEmpty(entrada.Nombre))
                return SalidaBase.Fallo(salida, Cadenas.album_falta_nombre);

            Album album;
            if (entrada.AlbumId > 0) {
                album = _gestorPersistencia.TraerAlbum(entrada.AlbumId);
                if (album == null) {
                    return SalidaBase.Fallo(salida, string.Format(Cadenas.album_id_no_encontrado, entrada.AlbumId));
                }
            } else {
                album = new Album
                    {
                        Nombre = entrada.Nombre,
                        FchCreacion = DateTime.Now,
                        AñoLanzamiento = entrada.AñoLanzamiento,
                    };
            }
            salida.Album = album;
            CrearVotable(album);
            _gestorPersistencia.Guardar(album);

            return SalidaBase.Exito(salida);
        }
        public EditarCancionSalida EditarCancion(EditarCancionEntrada entrada) {
            var salida = new EditarCancionSalida();

            if (string.IsNullOrEmpty(entrada.Nombre))
                return SalidaBase.Fallo(salida, Cadenas.cancion_falta_nombre);
            if (entrada.AlbumId != null) {
                Album album = _gestorPersistencia.TraerAlbum(entrada.AlbumId.Value);
                if (album == null)
                    return SalidaBase.Fallo(salida, string.Format(Cadenas.album_id_no_encontrado, entrada.AlbumId));
            }

            Cancion cancion;
            if (entrada.CancionId > 0) {
                cancion = _gestorPersistencia.TraerCancion(entrada.CancionId);
                if (cancion == null)
                    return SalidaBase.Fallo(salida, string.Format(Cadenas.cancion_id_no_encontrado, entrada.CancionId));
                cancion.AlbumId = entrada.AlbumId;
            } else {
                cancion = new Cancion
                    {
                        Id = entrada.CancionId,
                        FchCreacion = DateTime.Now,
                        Nombre = entrada.Nombre,
                        AlbumId = entrada.AlbumId
                    };
            }
            CrearVotable(cancion);
            _gestorPersistencia.Guardar(cancion);

            return SalidaBase.Exito(salida);
        }

        public RelacionarInterpretesACancionSalida RelacionarInterpretesACancion(RelacionarInterpretesACancionEntrada entrada) {
            var salida = new RelacionarInterpretesACancionSalida();

            var cancion = _gestorPersistencia.TraerCancion(entrada.CancionId);
            if (cancion == null)
                return SalidaBase.Fallo(salida, string.Format(Cadenas.cancion_id_no_encontrado, entrada.CancionId));

            if (cancion.AlbumId != null) {
                return SalidaBase.Fallo(salida, string.Format(Cadenas.cancion_asociada_a_album, cancion.AlbumId));
            }

            if (entrada.Interpretes == null || entrada.Interpretes.Count == 0)
                return SalidaBase.Fallo(salida, Cadenas.album_falta_interprete);

            int interpreteError = int.MinValue;
            var interpretes = TraerInterpretes(entrada.Interpretes, (noEncontrado => interpreteError = noEncontrado));
            if (interpreteError != int.MinValue) {
                return SalidaBase.Fallo(salida, string.Format(Cadenas.interprete_id_no_encontrado, interpreteError));
            }

            if (entrada.Accion == RelacionarInterpretesACancionEntrada.Acciones.Agregar) {
                var relaciones = interpretes.Select(i => _gestorPersistencia.TraerCancionInterprete(cancion.Id, i.Id));
                foreach (var relacion in relaciones) {
                    _gestorPersistencia.Guardar(relacion);
                }
            } else if (entrada.Accion == RelacionarInterpretesACancionEntrada.Acciones.Eliminar) {
                var relaciones = interpretes.Select(i => _gestorPersistencia.TraerCancionInterprete(cancion.Id, i.Id));
                foreach (var relacion in relaciones) {
                    _gestorPersistencia.EliminarCancionInterprete(relacion.InterpreteId, relacion.CancionId);
                }
            }

            return SalidaBase.Exito(salida);
        }
        public RelacionarInterpretesAAlbumSalida RelacionarInterpretesAAlbum(RelacionarInterpretesAAlbumEntrada entrada) {
            var salida = new RelacionarInterpretesAAlbumSalida();

            var album = _gestorPersistencia.TraerAlbum(entrada.AlbumId);
            if (album == null)
                return SalidaBase.Fallo(salida, string.Format(Cadenas.album_id_no_encontrado, entrada.AlbumId));

            if (entrada.Interpretes == null || entrada.Interpretes.Count == 0)
                return SalidaBase.Fallo(salida, Cadenas.album_falta_interprete);

            int interpreteError = int.MinValue;
            var interpretes = TraerInterpretes(entrada.Interpretes, (noEncontrado => interpreteError = noEncontrado));
            if (interpreteError != int.MinValue) {
                return SalidaBase.Fallo(salida, string.Format(Cadenas.interprete_id_no_encontrado, interpreteError));
            }

            if (entrada.Accion == RelacionarInterpretesAAlbumEntrada.Acciones.Agregar) {
                var relaciones = interpretes.Select(i => _gestorPersistencia.TraerAlbumInterprete(album.Id, i.Id)).ToList();
                foreach (var relacion in relaciones) {
                    _gestorPersistencia.Guardar(relacion);
                }
            } else if (entrada.Accion == RelacionarInterpretesAAlbumEntrada.Acciones.Eliminar) {
                var relaciones = interpretes.Select(i => _gestorPersistencia.TraerAlbumInterprete(album.Id, i.Id));
                foreach (var relacion in relaciones) {
                    _gestorPersistencia.EliminarAlbumInterprete(relacion.InterpreteId, relacion.AlbumId);
                }
            }

            return SalidaBase.Exito(salida);
        }
        public AsociarCancionYAlbumSalida AsociarCancionYAlbum(AsociarCancionYAlbumEntrada entrada) {
            var salida = new AsociarCancionYAlbumSalida();
            int cancionError = int.MinValue;
            var canciones = TraerCanciones(entrada.Canciones, (noEncontrado => cancionError = noEncontrado));
            if (cancionError != int.MinValue) {
                return SalidaBase.Fallo(salida, string.Format(Cadenas.cancion_id_no_encontrado, cancionError));
            }

            if (entrada.Accion == AsociarCancionYAlbumEntrada.Acciones.Asociar) {
                var album = _gestorPersistencia.TraerAlbum(entrada.AlbumId);
                if (album == null)
                    return SalidaBase.Fallo(salida, string.Format(Cadenas.album_id_no_encontrado, entrada.AlbumId));

                foreach (var cancion in canciones) {
                    cancion.AlbumId = album.Id;
                    _gestorPersistencia.EliminarCancionInterprete(cancion.Id);
                    _gestorPersistencia.Guardar(cancion);
                }
            } else if (entrada.Accion == AsociarCancionYAlbumEntrada.Acciones.Desasociar) {
                foreach (var cancion in canciones) {
                    cancion.AlbumId = null;
                    _gestorPersistencia.Guardar(cancion);
                }
            }

            return SalidaBase.Exito(salida);
        }

        public RegistrarVotoCancionesSalida RegistrarVotoCanciones(RegistrarVotoCancionesEntrada entrada) {
            var salida = new RegistrarVotoCancionesSalida();

            int cancionError = int.MinValue;
            var canciones = TraerCanciones(entrada.Canciones, (noEncontrado => cancionError = noEncontrado));
            if (cancionError != int.MinValue)
                return SalidaBase.Fallo(salida, string.Format(Cadenas.cancion_id_no_encontrado, cancionError));

            var usuario = _gestorPersistencia.TraerCancion(entrada.UsuarioId);
            if (usuario == null)
                return SalidaBase.Fallo(salida, string.Format(Cadenas.usuario_id_no_encontrado, entrada.UsuarioId));

            foreach (var cancion in canciones) {
                RegistrarVoto(cancion.VotableId, entrada.UsuarioId);
            }

            return SalidaBase.Exito(salida);
        }
        public RegistrarVotoAlbumesSalida RegistrarVotoAlbumes(RegistrarVotoAlbumesEntrada entrada) {
            var salida = new RegistrarVotoAlbumesSalida();

            int albumError = int.MinValue;
            var albumes = TraerAlbumes(entrada.Albumes, (noEncontrado => albumError = noEncontrado));
            if (albumError != int.MinValue)
                return SalidaBase.Fallo(salida, string.Format(Cadenas.album_id_no_encontrado, albumError));

            var usuario = _gestorPersistencia.TraerUsuario(entrada.UsuarioId);
            if (usuario == null)
                return SalidaBase.Fallo(salida, string.Format(Cadenas.usuario_id_no_encontrado, entrada.UsuarioId));

            foreach (var album in albumes) {
                RegistrarVoto(album.VotableId, entrada.UsuarioId);
            }

            return SalidaBase.Exito(salida);
        }
        public GenerarReporteSalida GenerarReporte(GenerarReporteEntrada entrada) {
            var salida = new GenerarReporteSalida();

            var fabrica = new FabricaReportes(_gestorPersistencia);
            var reporte = fabrica.TraerReporte(entrada.Tipo);
            if (reporte == null)
                return SalidaBase.Fallo(salida, string.Format(Cadenas.reporte_tipo_no_encontrado, entrada.Tipo));

            var resultValidar = reporte.Validar(entrada.Parametros);
            if (!string.IsNullOrEmpty(resultValidar)) {
                return SalidaBase.Fallo(salida,
                    string.Format("{0}\n{1}", Cadenas.reporte_error_parametros, resultValidar));
            }

            var consulta = reporte.Consultar();
            salida.Consulta = consulta;

            return SalidaBase.Exito(salida);
        }

        public Album TraerAlbum(int id) {
            return _gestorPersistencia.TraerAlbum(id);
        }
        public Interprete TraerInterprete(int id) {
            return _gestorPersistencia.TraerInterprete(id);
        }
        public IList<MVAlbum> TraerAlbumes(int pagina, string nombre, int? interprete) {
            return _gestorPersistencia.TraerAlbumes(pagina, nombre);
        }
        public IList<MVAlbum> TraerAlbumesInterprete(int interpreteId) {
            return _gestorPersistencia.TraerAlbumesInterprete(interpreteId);
        }
        public IList<MVAlbumDetallado> DetallarAlbumes(IList<MVAlbum> albumes) {
            return _gestorPersistencia.DetallarAlbumes(albumes);
        }
        public IList<MVCancion> TraerCanciones(int pagina, string nombre, FiltroAlbum filtroAlbum, int? album) {
            return _gestorPersistencia.TraerCanciones(pagina, nombre, filtroAlbum, album);
        }
        public IList<MVCancion> TraerCancionesAlbum(int albumId) {
            return _gestorPersistencia.TraerCancionesAlbum(albumId);
        }
        public IList<MVCancion> TraerCancionesInterprete(int interpreteId) {
            return _gestorPersistencia.TraerCancionesInterprete(interpreteId);
        }
        public IList<MVCancion> TraerCancionesMasVotadas(int cantidad) {
            return _gestorPersistencia.TraerCancionesMasVotadas(cantidad);
        }
        public IList<Interprete> TraerInterpretes(int pagina, string nombre) {
            return _gestorPersistencia.TraerInterpretes(pagina, nombre);
        }
        public IList<Interprete> TraerInterpretesAlbum(int albumId) {
            return _gestorPersistencia.TraerInterpretesAlbum(albumId);
        }
        public Cancion TraerCancion(int id) {
            return _gestorPersistencia.TraerCancion(id);
        }
        
        private void CrearVotable(IElementoVotable elementoVotable) {
            if (elementoVotable.VotableId > 0) return;

            // crear votable
            var votable = new Votable();
            _gestorPersistencia.Guardar(votable);
            elementoVotable.VotableId = votable.Id;
        }
        private void RegistrarVoto(int votable, int usuario) {
            var voto = _gestorPersistencia.TraerVotableUsuario(votable, usuario);
            if (voto != null) return;

            voto = new VotableUsuario {UsuarioId = usuario, VotableId = votable, FchCreacion = DateTime.Now};
            _gestorPersistencia.Guardar(voto);
        }
        private IList<Interprete> TraerInterpretes(IEnumerable<int> interpretes, Action<int> siNoEncuentra = null) {
            IList<Interprete> result = new List<Interprete>();
            foreach (var interpreteId in interpretes) {
                var interprete = _gestorPersistencia.TraerInterprete(interpreteId);
                if (interprete == null) {
                    if (siNoEncuentra != null) siNoEncuentra(interpreteId);
                } else {
                    result.Add(interprete);
                }
            }
            return result;
        }
        private IList<Album> TraerAlbumes(IEnumerable<int> albumes, Action<int> siNoEncuentra = null) {
            IList<Album> result = new List<Album>();
            foreach (var albumId in albumes) {
                var album = _gestorPersistencia.TraerAlbum(albumId);
                if (album == null) {
                    if (siNoEncuentra != null) siNoEncuentra(albumId);
                } else {
                    result.Add(album);
                }
            }
            return result;
        }
        private IList<Cancion> TraerCanciones(IEnumerable<int> canciones, Action<int> siNoEncuentra = null) {
            IList<Cancion> result = new List<Cancion>();
            foreach (var cancionId in canciones) {
                var cancion = _gestorPersistencia.TraerCancion(cancionId);
                if (cancion == null) {
                    if (siNoEncuentra != null) siNoEncuentra(cancionId);
                } else {
                    result.Add(cancion);
                }
            }
            return result;
        }
    }
}