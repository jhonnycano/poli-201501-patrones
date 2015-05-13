#region
using System;

#endregion

namespace Politecnico.Comunes {
    public static class UtilConsola {
        public static void MostrarOpciones<T>() where T : struct, IComparable, IFormattable {
            Type t = typeof (T);
            Array valores = Enum.GetValues(t);
            foreach (object v in valores) {
                Console.WriteLine("{0}:{1}", (int) v, Enum.Parse(t, v.ToString()));
            }
        }
        public static T LeerEnum<T>(string titulo = "Ingrese valor :>") where T : struct {
            T result;
            while (true) {
                Console.Write(titulo);
                string linea = Console.ReadLine();
                try {
                    if (!Enum.TryParse(linea, out result)) continue;
                    if (!Enum.IsDefined(typeof (T), result)) continue;
                    break;
                } catch {
                }
            }
            return result;
        }
        public static int LeerInt(string titulo = "Ingrese valor :>", int min = 0, int max = int.MaxValue) {
            int result;
            while (true) {
                Console.Write(titulo);
                string linea = Console.ReadLine();
                try {
                    if (!int.TryParse(linea, out result)) continue;
                    if (result < min || result > max) continue;
                    break;
                } catch {
                }
            }
            return result;
        }
        public static int LeerIntConDefault(int vrDefault, string titulo = "Ingrese valor :>", int min = 0, int max = int.MaxValue) {
            int result;
            while (true) {
                Console.Write(titulo);
                string linea = Console.ReadLine();
                try {
                    if (string.IsNullOrEmpty(linea)) return vrDefault;
                    if (!int.TryParse(linea, out result)) continue;
                    if (result < min || result > max) continue;
                    break;
                } catch {
                }
            }
            return result;
        }
        public static string LeerString(string titulo = "Ingrese valor :>") {
            Console.Write(titulo);
            string linea = Console.ReadLine();
            return linea;
        }
        public static void Pausa() {
            Console.ReadKey();
        }
        public static void Escribir(string texto, ConsoleColor consoleColor) {
            ConsoleColor colorActual = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(texto);
            Console.ForegroundColor = colorActual;
        }
    }
}