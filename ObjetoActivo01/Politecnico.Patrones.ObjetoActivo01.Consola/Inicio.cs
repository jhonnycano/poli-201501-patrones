using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Politecnico.Comunes;
using Politecnico.Patrones.ObjetoActivo01.Consola.Recursos;

namespace Politecnico.Patrones.ObjetoActivo01.Consola {
    public class Inicio {
        public static void Main(string[] args) {
            Console.WriteLine(Archivos.Inicio);
            while (true) {
                var cantidad = UtilConsola.LeerIntConDefault(10, Archivos.str_cuantos_trabajos, 0, 100);
                if (cantidad == 0) return;

                var iteraciones = UtilConsola.LeerIntConDefault(10, Archivos.str_cuantas_iteraciones, 1, 100);
                var peso = UtilConsola.LeerIntConDefault(500, Archivos.str_cuanto_peso, 1, 5000);

                var trabajos = Util.GenerarTrabajos(cantidad, peso, iteraciones);
                var rutaArchivo = Path.Combine(Environment.CurrentDirectory, "log.txt");
                var log = new Logger(rutaArchivo);
                Action<Trabajo> miAccion = t => {
                    for (int i = 0; i < t.Cantidad; i++) {
                        log.Log(LoggerTask.Tipo.Informacion, string.Format("Trabajo {0} paso {1} inicia", t.Id, i));
                        Thread.Sleep(t.Peso);
                        log.Log(LoggerTask.Tipo.Informacion, string.Format("Trabajo {0} paso {1} termina", t.Id, i));
                    }
                };

                var tareas = (from trabajo in trabajos select Task.Run(() => miAccion(trabajo))).ToArray();

                // esperar finalización de tareas
                Task.WaitAll(tareas);
                UtilConsola.Escribir(Archivos.str_trabajos_terminados, ConsoleColor.Green);
                var abrir = UtilConsola.LeerString("¿Desea abrir el archivo? (s/n)");
                if (abrir.Equals("s", StringComparison.OrdinalIgnoreCase)) {
                    Process.Start("notepad.exe", rutaArchivo);
                }
                //Console.ReadKey(true);
            }
        }
    }
}