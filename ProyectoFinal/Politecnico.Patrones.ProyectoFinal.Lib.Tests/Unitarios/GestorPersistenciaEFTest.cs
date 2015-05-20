using System;
using System.Linq;
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
            var interpretes = (from i in g.DbSetInterprete select i).ToList();
            foreach (var interprete in interpretes) {
                Console.WriteLine(interprete.Nombre);
            }
        }
    }
}