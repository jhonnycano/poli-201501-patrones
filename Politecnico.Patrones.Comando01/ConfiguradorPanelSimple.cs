using System;
using Politecnico.Patrones.Comando01.ComandosSimples;
using Politecnico.Patrones.Comando01.Paneles;
using Politecnico.Patrones.Comando01.Perifericos;

namespace Politecnico.Patrones.Comando01 {
    public class ConfiguradorPanelSimple {
        public enum AccionesEquipoSonido { EncenderYApagar, EmisoraYCD, }
        public enum AccionesTelevisor { EncenderYApagar, SintonizarCanales, }

        private readonly PanelSimple _panel;
        private readonly Casa _casa;
        public ConfiguradorPanelSimple(PanelSimple panel, Casa casa) {
            _panel = panel;
            _casa = casa;
        }
        public void RegistrarAccionesBombillo(int pos, string nombre) {
            if (!_casa.Bombillos.ContainsKey(nombre)) {
                Console.WriteLine("bombillo " + nombre + " no encontrado");
                return;
            }
            var bombillo = _casa.Bombillos[nombre];
            var comandoActivar = new ComandoEncenderBombillo(bombillo);
            var comandoInactivar = new ComandoApagarBombillo(bombillo);
            _panel.RegistrarAccion(pos, comandoActivar, comandoInactivar);
        }
        public void RegistrarAccionesEquipoSonido(int pos, string nombre, AccionesEquipoSonido accion, params string[] args) {
            if (!_casa.EquiposSonido.ContainsKey(nombre)) {
                Console.WriteLine("equipo de sonido " + nombre + " no encontrado");
                return;
            }
            var equipoSonido = _casa.EquiposSonido[nombre];
            var tupla = TraerComandosEquipoSonido(accion, equipoSonido, args);
            if (tupla == null) {
                Console.WriteLine("accion no reconocida");
                return;
            }

            IComando comandoActivar = tupla.Item1;
            IComando comandoInactivar = tupla.Item2;
            _panel.RegistrarAccion(pos, comandoActivar, comandoInactivar);
        }
        public void RegistrarAccionesTelevisor(int pos, string nombre, AccionesTelevisor accion, params string[] args) {
            if (!_casa.Televisores.ContainsKey(nombre)) {
                Console.WriteLine("televisor " + nombre + " no encontrado");
                return;
            }
            var televisor = _casa.Televisores[nombre];
            var tupla = TraerComandosTelevisor(accion, televisor, args);
            if (tupla == null) {
                Console.WriteLine("accion no reconocida");
                return;
            }

            IComando comandoActivar = tupla.Item1;
            IComando comandoInactivar = tupla.Item2;
            _panel.RegistrarAccion(pos, comandoActivar, comandoInactivar);
        }
        public void RegistrarAccionesCortina(int pos, string nombre) {
            if (!_casa.Cortinas.ContainsKey(nombre)) {
                Console.WriteLine("cortina " + nombre + " no encontrada");
                return;
            }
            var cortina = _casa.Cortinas[nombre];
            var comandoActivar = new ComandoAbrirCortina(cortina);
            var comandoInactivar = new ComandoCerrarCortina(cortina);
            _panel.RegistrarAccion(pos, comandoActivar, comandoInactivar);
        }
        private static Tuple<IComando, IComando> TraerComandosEquipoSonido(AccionesEquipoSonido accion, EquipoSonido equipoSonido, params string[] args) {
            switch (accion) {
                case AccionesEquipoSonido.EncenderYApagar:
                    return new Tuple<IComando, IComando>(
                        new ComandoEncenderEquipo(equipoSonido),
                        new ComandoApagarEquipo(equipoSonido));
                case AccionesEquipoSonido.EmisoraYCD:
                    if (args.Length < 2) {
                        Console.WriteLine("Faltan parametros para configurar equipo de sonido");
                        return null;
                    }
                    return new Tuple<IComando, IComando>(
                        new ComandoSintonizarEmisoraEquipo(equipoSonido, args[0]),
                        new ComandoEjecutarCDEquipo(equipoSonido, args[1]));
            }
            return null;
        }
        private Tuple<IComando, IComando> TraerComandosTelevisor(AccionesTelevisor accion, Televisor televisor, string[] args) {
            switch (accion) {
                case AccionesTelevisor.EncenderYApagar:
                    return new Tuple<IComando, IComando>(
                        new ComandoEncenderTelevisor(televisor), 
                        new ComandoApagarTelevisor(televisor));
                case AccionesTelevisor.SintonizarCanales:
                    if (args.Length < 2) {
                        Console.WriteLine("Faltan parametros para configurar televisor");
                        return null;
                    }
                    return new Tuple<IComando, IComando>(
                        new ComandoSintonizarCanalTelevisor(televisor, args[0]), 
                        new ComandoSintonizarCanalTelevisor(televisor, args[1]));
            }
            return null;
        }
    }
}