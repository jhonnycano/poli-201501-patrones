using System;
using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;
using Politecnico.Patrones.ProyectoFinal.Lib.VO;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public class GestorDominio : IGestorDominio {
        private readonly IGestorPersistencia _gestorPersistencia;
        public GestorDominio(IGestorPersistencia gestorPersistencia) {
            _gestorPersistencia = gestorPersistencia;
        }
        public EditarCancionSalida EditarCancion(EditarCancionEntrada entrada) {
            Cancion cancion;
            if (entrada.CancionId == 0) {
                cancion = new Cancion
                    {
                        Id = entrada.CancionId,
                        Nombre = entrada.Nombre,
                        InterpreteId = entrada.InterpreteId,
                        AlbumId = entrada.AlbumId
                    };
            } else {
                cancion = _gestorPersistencia.TraerCancion(entrada.CancionId);
            }
            if (cancion.Votable <= 0) {
                // crear votable
            }
            _gestorPersistencia.Guardar(cancion);
            var salida = new EditarCancionSalida(SalidaBase.Resultados.Exito);
            return salida;
        }
        public EditarInterpreteSalida EditarInterprete(EditarInterpreteEntrada entrada) {
            var interprete = new Interprete
                {
                    Id = entrada.InterpreteId,
                    Nombre = entrada.Nombre,
                };
            _gestorPersistencia.Guardar(interprete);
            var salida = new EditarInterpreteSalida(SalidaBase.Resultados.Exito);
            return salida;
        }
        public EditarAlbumSalida EditarAlbum(EditarAlbumEntrada entrada) {
            var album = new Album
                {
                    Id = entrada.AlbumId,
                    Nombre = entrada.Nombre,
                    InterpreteId = entrada.InterpreteId,
                };
            _gestorPersistencia.Guardar(album);
            var salida = new EditarAlbumSalida(SalidaBase.Resultados.Exito);
            return salida;
        }
        public AsociarCancionYAlbumSalida AsociarCancionYAlbum(AsociarCancionYAlbumEntrada entrada) {
            throw new NotImplementedException();
        }
        public RegistrarVotoCancionSalida RegistrarVotoCancion(RegistrarVotoCancionEntrada entrada) {
            throw new NotImplementedException();
        }
        public RegistrarVotoAlbumSalida RegistrarVotoAlbum(RegistrarVotoAlbumEntrada entrada) {
            throw new NotImplementedException();
        }
        public GenerarReporteSalida GenerarReporte(GenerarReporteEntrada entrada) {
            throw new NotImplementedException();
        }
    }
}