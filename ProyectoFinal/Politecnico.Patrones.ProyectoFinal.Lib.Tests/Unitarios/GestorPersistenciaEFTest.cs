using System;
using NUnit.Framework;
using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Tests.Unitarios {
    [TestFixture]
    public class GestorPersistenciaEFTest {
        [SetUp]
        public void Inicializar() {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<GestorPersistenciaEF>());
        }
        [Test]
        public void GuardarBasico() {
            var g = new GestorPersistenciaEF();
            var interprete = new Interprete {Nombre = "pruebas"};
            g.Guardar(interprete);
        }
        [Test]
        public void TraerInterpretesBasico() {
            var g = new GestorPersistenciaEF();
            var interpretes = g.TraerInterpretes(0, "");

            foreach (var interprete in interpretes) {
                Console.WriteLine(interprete.Nombre);
            }
        }
        [Test]
        public void CrearAlbumBasico() {
            var g = new GestorPersistenciaEF();
            var album = new Album {Nombre = "Album pruebas"};
            g.Guardar(album);

            Assert.IsTrue(album.Id > 0);
        }
        [Test]
        public void CrearVotableBasico() {
            var g = new GestorPersistenciaEF();
            var votable = new Votable();
            g.Guardar(votable);

            Assert.IsTrue(votable.Id > 0);
        }

    }
}