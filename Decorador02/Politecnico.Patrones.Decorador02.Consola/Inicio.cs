#region
using System;
using System.IO;
using Politecnico.Comunes;
using Politecnico.Patrones.Decorador02.Recursos;

#endregion

namespace Politecnico.Patrones.Decorador02.Consola {
    internal class Inicio {
        private static IDecoradorHtml _decorador;
        private static string _archivo;

        private enum OpcionesConsola {
            Salir,
            VerAyuda,
            ConfigurarDecorador,
            LeerCadenas,
            GenerarArchivo,
        }

        private static void Main() {
            Console.Clear();
            Console.WriteLine(Archivos.Inicio);

            while (true) {
                UtilConsola.MostrarOpciones<OpcionesConsola>();
                var opcion = UtilConsola.LeerEnum<OpcionesConsola>();
                switch (opcion) {
                    case OpcionesConsola.Salir:
                        return;
                    case OpcionesConsola.VerAyuda:
                        VerAyuda();
                        break;
                    case OpcionesConsola.ConfigurarDecorador:
                        ConfigurarDecorador();
                        break;
                    case OpcionesConsola.LeerCadenas:
                        LeerCadena();
                        break;
                    case OpcionesConsola.GenerarArchivo:
                        GenerarArchivo();
                        break;
                }
            }
        }

        private static void VerAyuda() {
            Console.Clear();
            Console.WriteLine(Archivos.AyudaArchivo);
        }

        private static void ConfigurarDecorador() {
            while (true) {
                Console.Write(@"Ingrese ruta del archivo ( ! para regresar ) : ");
                _archivo = Console.ReadLine();
                if (_archivo == "!") {
                    _archivo = null;
                    return;
                }

                if (_archivo == null || !File.Exists(_archivo)) {
                    UtilConsola.Escribir("Archivo no existe", ConsoleColor.Red);
                    Console.ReadKey(true);
                    continue;
                }

                var cargador = new CargadorDecoradores();
                var contenido = File.ReadAllText(_archivo);
                _decorador = cargador.CargarDesdeCadena(contenido);

                break;
            }
        }

        private static void LeerCadena() {
            if (_decorador == null) {
                UtilConsola.Escribir("Debe configurar primero el decorador", ConsoleColor.Red);
                Console.ReadKey(true);
                return;
            }
            while (true) {
                var entrada = UtilConsola.LeerString("Ingrese cadena a decorar ( ! para regresar ) :>");
                if (entrada == "!") break;

                string result = _decorador.Decorar(entrada);
                Console.WriteLine(result);
                Console.ReadKey(true);
            }
        }

        private static void GenerarArchivo() {
            const string contenido = @"DecoradorCursiva
DecoradorNegrilla
DecoradorFuenteHtml4|{Color:'#decafe#', Tipo:'Arial', Tam:'16px'}
";
            var rutaDestino = Path.Combine(Environment.CurrentDirectory, "config.txt");
            File.WriteAllText(rutaDestino, contenido);

            UtilConsola.Escribir("Archivo de prueba guardado en ", ConsoleColor.Green);
            UtilConsola.Escribir(rutaDestino, ConsoleColor.Green);
            Console.ReadKey(true);
        }
    }
}