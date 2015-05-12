using System;
using System.Text;
using Politecnico.Comunes;

namespace Politecnico.Patrones.Composite01.Consola {
    public class Inicio {
        public static void Main(string[] args) {
            while (true) {
                UtilConsola.Escribir("Ingrese una ruta de sistema de archivos (vacio:salir):>", ConsoleColor.DarkYellow);
                var ruta = UtilConsola.LeerString("");
                if (string.IsNullOrEmpty(ruta)) break;

                var elemento = ElementoSistemaArchivos.Crear(ruta);
                if (elemento == null) {
                    UtilConsola.Escribir("Ruta no válida", ConsoleColor.Red);
                    continue;
                }

                var sb = new StringBuilder();
                elemento.Imprimir(sb, 0);
                Console.WriteLine(sb);
            }
        }
    }
}