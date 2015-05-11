#region
using System;

#endregion

namespace Politecnico.Patrones.Comando01.Perifericos {
    public class Televisor {
        private readonly string _nombre;
        public Televisor(string nombre) {
            _nombre = nombre;
        }
        public void Encender() {
            Console.WriteLine("Televisor " + _nombre + " encendido");
        }
        public void Apagar() {
            Console.WriteLine("Televisor " + _nombre + " apagado");
        }
        public void SintonizarCanal(string canal) {
            Console.WriteLine("Televisor " + _nombre + " en canal " + canal);
        }
    }
}