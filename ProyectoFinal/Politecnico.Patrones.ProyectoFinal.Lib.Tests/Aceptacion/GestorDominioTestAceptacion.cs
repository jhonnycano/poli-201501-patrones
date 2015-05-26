using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;
using Politecnico.Patrones.ProyectoFinal.Lib.Recursos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Tests.Aceptacion {
    [TestFixture]
    public class GestorDominioTestAceptacion {
        private GestorDominio _gestorDominio;
        private IGestorPersistencia _gestorPersistencia;

        [SetUp]
        public void Inicializar() {
            _gestorPersistencia = new GestorPersistenciaEF();
            _gestorDominio = new GestorDominio(_gestorPersistencia);
        }

        [TearDown]
        public void Limpiar() {
            var cancion = _gestorPersistencia.TraerCancion(5);
            cancion.AlbumId = null;
            _gestorPersistencia.Guardar(cancion);
            _gestorPersistencia.EliminarCancionInterprete(5);
            _gestorPersistencia.EliminarCancionInterprete(6);
            _gestorPersistencia.Guardar(new CancionInterprete {CancionId = 5, InterpreteId = 3});
            _gestorPersistencia.Guardar(new CancionInterprete {CancionId = 5, InterpreteId = 4});
            _gestorPersistencia.Guardar(new CancionInterprete {CancionId = 6, InterpreteId = 3});
            _gestorPersistencia.Guardar(new CancionInterprete {CancionId = 6, InterpreteId = 4});
        }

        [Test]
        public void CrearInterprete_SinNombre_Falla() {
            var entrada = new EditarInterpreteEntrada
                {
                    Nombre = "",
                };

            var salida = _gestorDominio.EditarInterprete(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(Cadenas.interprete_falta_nombre, salida.Mensaje);
        }
        [Test]
        public void CrearInterprete_TodoNormal_Funciona() {
            var entrada = new EditarInterpreteEntrada
                {
                    Nombre = "Interprete de pruebas",
                };

            var salida = _gestorDominio.EditarInterprete(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Exito);
        }
        [Test]
        public void EditarInterprete_SiNoExiste_Falla() {
            var entrada = new EditarInterpreteEntrada
                {
                    InterpreteId = 10000000,
                    Nombre = "Interprete de pruebas",
                };

            var salida = _gestorDominio.EditarInterprete(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(string.Format(Cadenas.interprete_id_no_encontrado, 10000000), salida.Mensaje);
        }
        [Test]
        public void EditarInterprete_QuitarNombre_Falla() {
            var entrada = new EditarInterpreteEntrada
                {
                    InterpreteId = 1,
                    Nombre = "",
                };

            var salida = _gestorDominio.EditarInterprete(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(Cadenas.interprete_falta_nombre, salida.Mensaje);
        }

        [Test]
        public void CrearAlbum_SinNombre_Falla() {
            var entrada = new EditarAlbumEntrada
                {
                    Nombre = "",
                };

            var salida = _gestorDominio.EditarAlbum(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(Cadenas.album_falta_nombre, salida.Mensaje);
        }
        [Test]
        public void EditarAlbum_SiNoExiste_Falla() {
            var entrada = new EditarAlbumEntrada
                {
                    AlbumId = 10000000,
                    Nombre = "Interprete de pruebas",
                };

            var salida = _gestorDominio.EditarAlbum(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(string.Format(Cadenas.album_id_no_encontrado, 10000000), salida.Mensaje);
        }
        [Test]
        public void EditarAlbum_QuitarNombre_Falla() {
            var entrada = new EditarAlbumEntrada
                {
                    AlbumId = 1,
                    Nombre = "",
                };

            var salida = _gestorDominio.EditarAlbum(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(Cadenas.album_falta_nombre, salida.Mensaje);
        }

        [Test]
        public void RelacionarInterpretesAAlbum_AlbumNoExiste_Falla() {
            var entrada = new RelacionarInterpretesAAlbumEntrada
                {
                    AlbumId = 10000000,
                    Interpretes = new List<int> {1},
                    Accion = RelacionarInterpretesAAlbumEntrada.Acciones.Agregar,
                };

            var salida = _gestorDominio.RelacionarInterpretesAAlbum(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(string.Format(Cadenas.album_id_no_encontrado, 10000000), salida.Mensaje);
        }
        [Test]
        public void RelacionarInterpretesAAlbum_SinInterpretes_Falla() {
            var entrada = new RelacionarInterpretesAAlbumEntrada
                {
                    AlbumId = 1,
                    Interpretes = null,
                    Accion = RelacionarInterpretesAAlbumEntrada.Acciones.Agregar,
                };

            var salida = _gestorDominio.RelacionarInterpretesAAlbum(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(Cadenas.album_falta_interprete, salida.Mensaje);
        }
        [Test]
        public void RelacionarInterpretesAAlbum_InterpretesNoExisten_Falla() {
            var entrada = new RelacionarInterpretesAAlbumEntrada
                {
                    AlbumId = 1,
                    Interpretes = new List<int> {10000000},
                    Accion = RelacionarInterpretesAAlbumEntrada.Acciones.Agregar,
                };

            var salida = _gestorDominio.RelacionarInterpretesAAlbum(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(string.Format(Cadenas.interprete_id_no_encontrado, 10000000), salida.Mensaje);
        }
        [Test]
        public void RelacionarInterpretesAAlbum_TodoNormal_Funciona() {
            var entrada = new RelacionarInterpretesAAlbumEntrada
                {
                    AlbumId = 1,
                    Interpretes = new List<int> {1, 2},
                    Accion = RelacionarInterpretesAAlbumEntrada.Acciones.Agregar,
                };

            var salida = _gestorDominio.RelacionarInterpretesAAlbum(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Exito);
            var interpretesAlbum = _gestorDominio.TraerInterpretesAlbum(1);
            Assert.IsTrue(interpretesAlbum.All(i => i.Id == 1 || i.Id == 2));
        }

        [Test]
        public void CrearCancion_SinNombre_Falla() {
            var entrada = new EditarCancionEntrada
                {
                    Nombre = "",
                };

            var salida = _gestorDominio.EditarCancion(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(Cadenas.cancion_falta_nombre, salida.Mensaje);
        }
        [Test]
        public void CrearCancion_AlbumNoExiste_Falla() {
            var entrada = new EditarCancionEntrada
                {
                    Nombre = "Cancion de pruebas",
                    AlbumId = 10000000
                };

            var salida = _gestorDominio.EditarCancion(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(string.Format(Cadenas.album_id_no_encontrado, entrada.AlbumId), salida.Mensaje);
        }
        [Test]
        public void EditarCancion_SiNoExiste_Falla() {
            var entrada = new EditarCancionEntrada
                {
                    CancionId = 10000000,
                    Nombre = "Interprete de pruebas",
                };

            var salida = _gestorDominio.EditarCancion(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(string.Format(Cadenas.cancion_id_no_encontrado, 10000000), salida.Mensaje);
        }
        [Test]
        public void EditarCancion_QuitarNombre_Falla() {
            var entrada = new EditarCancionEntrada
                {
                    CancionId = 1,
                    Nombre = "",
                };

            var salida = _gestorDominio.EditarCancion(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(Cadenas.cancion_falta_nombre, salida.Mensaje);
        }

        [Test]
        public void RelacionarInterpretesACancion_CancionNoExiste_Falla() {
            var entrada = new RelacionarInterpretesACancionEntrada
                {
                    CancionId = 10000000,
                    Interpretes = new List<int> {1},
                    Accion = RelacionarInterpretesACancionEntrada.Acciones.Agregar,
                };

            var salida = _gestorDominio.RelacionarInterpretesACancion(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(string.Format(Cadenas.cancion_id_no_encontrado, 10000000), salida.Mensaje);
        }
        [Test]
        public void RelacionarInterpretesACancion_CancionAsociadaAAlbum_Falla() {
            var entrada = new RelacionarInterpretesACancionEntrada
                {
                    CancionId = 1,
                    Interpretes = new List<int> {1},
                    Accion = RelacionarInterpretesACancionEntrada.Acciones.Agregar,
                };

            var salida = _gestorDominio.RelacionarInterpretesACancion(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(string.Format(Cadenas.cancion_asociada_a_album, 1), salida.Mensaje);
        }
        [Test]
        public void RelacionarInterpretesACancion_SinInterpretes_Falla() {
            var entrada = new RelacionarInterpretesACancionEntrada
                {
                    CancionId = 5,
                    Interpretes = null,
                    Accion = RelacionarInterpretesACancionEntrada.Acciones.Agregar,
                };

            var salida = _gestorDominio.RelacionarInterpretesACancion(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(Cadenas.album_falta_interprete, salida.Mensaje);
        }
        [Test]
        public void RelacionarInterpretesACancion_InterpretesNoExisten_Falla() {
            var entrada = new RelacionarInterpretesACancionEntrada
                {
                    CancionId = 5,
                    Interpretes = new List<int> {10000000},
                    Accion = RelacionarInterpretesACancionEntrada.Acciones.Agregar,
                };

            var salida = _gestorDominio.RelacionarInterpretesACancion(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(string.Format(Cadenas.interprete_id_no_encontrado, 10000000), salida.Mensaje);
        }
        [Test]
        public void RelacionarInterpretesACancion_TodoNormal_Funciona() {
            var entrada = new RelacionarInterpretesACancionEntrada
                {
                    CancionId = 5,
                    Interpretes = new List<int> {2, 3},
                    Accion = RelacionarInterpretesACancionEntrada.Acciones.Agregar,
                };

            var salida = _gestorDominio.RelacionarInterpretesACancion(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Exito);
        }

        [Test]
        public void AsociarCancionYAlbum_CancionNoExiste_Falla() {
            var entrada = new AsociarCancionYAlbumEntrada
                {
                    CancionId = 10000000,
                    AlbumId = 3,
                    Accion = AsociarCancionYAlbumEntrada.Acciones.Asociar,
                };

            var salida = _gestorDominio.AsociarCancionYAlbum(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(string.Format(Cadenas.cancion_id_no_encontrado, 10000000), salida.Mensaje);
        }
        [Test]
        public void AsociarCancionYAlbum_AlbumNoExiste_Falla() {
            var entrada = new AsociarCancionYAlbumEntrada
                {
                    CancionId = 1,
                    AlbumId = 10000000,
                    Accion = AsociarCancionYAlbumEntrada.Acciones.Asociar,
                };

            var salida = _gestorDominio.AsociarCancionYAlbum(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Fallo);
            Assert.AreEqual(string.Format(Cadenas.album_id_no_encontrado, 10000000), salida.Mensaje);
        }
        [Test]
        public void AsociarCancionYAlbum_CancionConInterpretes_QuedaSinInterpretes() {
            var entrada = new AsociarCancionYAlbumEntrada
                {
                    CancionId = 6,
                    AlbumId = 3
                };

            var salida = _gestorDominio.AsociarCancionYAlbum(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Exito);
            Assert.IsTrue(_gestorPersistencia.TraerCancion(6).AlbumId == 3);
            Assert.IsTrue(_gestorPersistencia.TraerInterpretesCancion(6).Count == 0);

            _gestorPersistencia.EliminarCancionInterprete(6);
        }
        [Test]
        public void AsociarCancionYAlbum_CancionSinInterpretes_Funciona() {
            var entrada = new AsociarCancionYAlbumEntrada
                {
                    CancionId = 7,
                    AlbumId = 3
                };

            var salida = _gestorDominio.AsociarCancionYAlbum(entrada);

            Assert.IsTrue(salida == SalidaBase.Resultados.Exito);
            Assert.IsTrue(_gestorPersistencia.TraerCancion(7).AlbumId == 3);
            Assert.IsTrue(_gestorPersistencia.TraerInterpretesCancion(7).Count == 0);
        }
    }
}