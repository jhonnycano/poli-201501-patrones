#region
using System;

#endregion

namespace Politecnico.Patrones.Comando01.Perifericos {
    public class EquipoSonido {
        public enum EquipoSonidoEstado {
            Apagado,
            Encendido
        }

        public enum EquipoSonidoModo {
            Radio,
            CD,
            Auxiliar
        }

        private readonly string _nombre;
        private string _cd;
        private EquipoSonidoEstado _estado;
        private EquipoSonidoModo _modo = EquipoSonidoModo.Radio;
        public EquipoSonido(string nombre) {
            _nombre = nombre;
        }
        public void Encender() {
            if (_estado == EquipoSonidoEstado.Apagado) {
                _estado = EquipoSonidoEstado.Encendido;
                Console.WriteLine("Eq.Sonido " + _nombre + " encendido");
            }
        }
        public void Apagar() {
            if (_estado == EquipoSonidoEstado.Encendido) {
                _estado = EquipoSonidoEstado.Apagado;
                Console.WriteLine("Eq.Sonido " + _nombre + " apagado");
            }
        }
        public void SintonizarEmisora(string emisora) {
            CambiarModo(EquipoSonidoModo.Radio);
            Console.WriteLine("Eq.Sonido " + _nombre + " Emisora " + emisora);
        }
        public void InsertarCD(string cd) {
            CambiarModo(EquipoSonidoModo.CD);
            if (_cd != null) {
                Console.WriteLine("Eq.Sonido " + _nombre + " extraiga primero el CD");
                return;
            }
            _cd = cd;
            Console.WriteLine("Eq.Sonido " + _nombre + " CD ingresado" + _cd);
        }
        public void ExtraerCD() {
            _cd = null;
            Console.WriteLine("Eq.Sonido " + _nombre + " CD extraido");
        }
        public void EjecutarCD() {
            if (_cd == null) {
                Console.WriteLine("Eq.Sonido " + _nombre + " inserte CD");
                return;
            }
            Console.WriteLine("Eq.Sonido " + _nombre + " ejecutando CD " + _cd);
        }
        private void CambiarModo(EquipoSonidoModo modo) {
            if (_modo != modo) {
                _modo = modo;
                Console.WriteLine("Eq.Sonido " + _nombre + " encendido");
            }
        }
    }
}