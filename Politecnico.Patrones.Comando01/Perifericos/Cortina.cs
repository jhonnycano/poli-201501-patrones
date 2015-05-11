#region
using System;

#endregion

namespace Politecnico.Patrones.Comando01.Perifericos {
    public class Cortina {
        private readonly string _nombre;
        public Cortina(string nombre) {
            _nombre = nombre;
        }
        public void Abrir() {
            Console.WriteLine("Cortina " + _nombre + " abierta");
        }
        public void Cerrar() {
            Console.WriteLine("Cortina " + _nombre + " cerrada");
        }
    }
}