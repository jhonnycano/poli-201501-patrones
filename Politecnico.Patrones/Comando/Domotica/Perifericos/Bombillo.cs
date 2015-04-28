using System;

namespace Politecnico.Patrones.Comando.Domotica.Perifericos {
    public class Bombillo {
        private readonly string _nombre;
        public Bombillo(string nombre) {
            _nombre = nombre;
        }
        public void Encender() {
            Console.WriteLine("Bombillo " + _nombre + " encendido");
        }
        public void Apagar() {
            Console.WriteLine("Bombillo " + _nombre + " apagado");
        }
    }
}