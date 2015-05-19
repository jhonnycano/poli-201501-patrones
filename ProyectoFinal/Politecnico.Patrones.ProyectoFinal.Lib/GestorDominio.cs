using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;
using Politecnico.Patrones.ProyectoFinal.Lib.VO;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public class GestorDominio : IGestorDominio {
        private readonly IGestorPersistencia _gestorPersistencia;
        public GestorDominio(IGestorPersistencia gestorPersistencia) {
            _gestorPersistencia = gestorPersistencia;
        }
        public EditarCancionSalida EditarCancion(EditarCancionEntrada entrada) {
            var salida = new EditarCancionSalida();
            Cancion cancion;
            if (entrada.CancionId <= 0) {
                cancion = new Cancion
                    {
                        Id = entrada.CancionId,
                        Nombre = entrada.Nombre,
                        InterpreteId = entrada.InterpreteId,
                        AlbumId = entrada.AlbumId
                    };
            } else {
                cancion = _gestorPersistencia.TraerCancion(entrada.CancionId);
                if (cancion == null) {
                    return SalidaBase.Fallo(salida, "Canción con id " + entrada.CancionId + "no encontrada");
                }
            }
            CrearVotable(cancion);
            _gestorPersistencia.Guardar(cancion);

            return SalidaBase.Exito(salida);
        }
        public EditarInterpreteSalida EditarInterprete(EditarInterpreteEntrada entrada) {
            var salida = new EditarInterpreteSalida();
            var interprete = new Interprete
                {
                    Id = entrada.InterpreteId,
                    Nombre = entrada.Nombre,
                };
            _gestorPersistencia.Guardar(interprete);

            return SalidaBase.Exito(salida);
        }
        public EditarAlbumSalida EditarAlbum(EditarAlbumEntrada entrada) {
            var salida = new EditarAlbumSalida();
            Album album;
            if (entrada.AlbumId <= 0) {
                album = new Album
                    {
                        Id = entrada.AlbumId,
                        Nombre = entrada.Nombre,
                        InterpreteId = entrada.InterpreteId,
                    };
            } else {
                album = _gestorPersistencia.TraerAlbum(entrada.AlbumId);
                if (album == null) {
                    return SalidaBase.Fallo(salida, "Album con id " + entrada.AlbumId + "no encontrado");
                }
            }
            CrearVotable(album);
            _gestorPersistencia.Guardar(album);

            return SalidaBase.Exito(salida);
        }
        public AsociarCancionYAlbumSalida AsociarCancionYAlbum(AsociarCancionYAlbumEntrada entrada) {
            var salida = new AsociarCancionYAlbumSalida();
            var cancion = _gestorPersistencia.TraerCancion(entrada.CancionId);
            if (cancion == null) {
                return SalidaBase.Fallo(salida, "Canción con id " + entrada.CancionId + "no encontrada");
            }

            if (entrada.Accion == AsociarCancionYAlbumEntrada.Acciones.Asociar) {
                var album = _gestorPersistencia.TraerAlbum(entrada.AlbumId);
                if (album == null) {
                    return SalidaBase.Fallo(salida, "Album con id " + entrada.AlbumId + "no encontrado");
                }

                cancion.AlbumId = album.Id;
            } else if (entrada.Accion == AsociarCancionYAlbumEntrada.Acciones.Desasociar) {
                cancion.AlbumId = null;
            }

            _gestorPersistencia.Guardar(cancion);

            return SalidaBase.Exito(salida);
        }
        public RegistrarVotoCancionSalida RegistrarVotoCancion(RegistrarVotoCancionEntrada entrada) {
            var salida = new RegistrarVotoCancionSalida();
            var cancion = _gestorPersistencia.TraerCancion(entrada.CancionId);
            if (cancion == null) {
                return SalidaBase.Fallo(salida, "Canción con id " + entrada.CancionId + "no encontrada");
            }
            var usuario = _gestorPersistencia.TraerCancion(entrada.UsuarioId);
            if (usuario == null) {
                return SalidaBase.Fallo(salida, "Usuario con id " + entrada.UsuarioId + "no encontrado");
            }

            var voto = _gestorPersistencia.TraerVotableUsuario(cancion.VotableId, entrada.UsuarioId);
            if (voto != null) {
                return SalidaBase.Fallo(salida, "Voto ya registrado");
            }

            voto = new VotableUsuario {UsuarioId = entrada.UsuarioId, VotableId = cancion.VotableId};
            _gestorPersistencia.Guardar(voto);

            return SalidaBase.Exito(salida);
        }
        public RegistrarVotoAlbumSalida RegistrarVotoAlbum(RegistrarVotoAlbumEntrada entrada) {
            var salida = new RegistrarVotoAlbumSalida();
            var cancion = _gestorPersistencia.TraerCancion(entrada.AlbumId);
            if (cancion == null) {
                return SalidaBase.Fallo(salida, "Canción con id " + entrada.AlbumId + "no encontrada");
            }
            var usuario = _gestorPersistencia.TraerCancion(entrada.UsuarioId);
            if (usuario == null) {
                return SalidaBase.Fallo(salida, "Usuario con id " + entrada.UsuarioId + "no encontrado");
            }

            var voto = _gestorPersistencia.TraerVotableUsuario(cancion.VotableId, entrada.UsuarioId);
            if (voto != null) {
                return SalidaBase.Fallo(salida, "Voto ya registrado");
            }

            voto = new VotableUsuario {UsuarioId = entrada.UsuarioId, VotableId = cancion.VotableId};
            _gestorPersistencia.Guardar(voto);

            return SalidaBase.Exito(salida);
        }
        public GenerarReporteSalida GenerarReporte(GenerarReporteEntrada entrada) {
            var salida = new GenerarReporteSalida();
            return SalidaBase.Fallo(salida, "No implementado");
        }

        private void CrearVotable(IElementoVotable elementoVotable) {
            if (elementoVotable.VotableId > 0) return;

            // crear votable
            var votable = new Votable();
            _gestorPersistencia.Guardar(votable);
            elementoVotable.VotableId = votable.Id;
        }

    }
}
