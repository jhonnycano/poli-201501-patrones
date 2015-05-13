#region
using System;
using Politecnico.Comunes;
using Politecnico.Patrones.Comando01.Paneles;

#endregion

namespace Politecnico.Patrones.Comando01.Consola {
    public class Inicio {
        public static void Main(string[] args) {
            var casa = CrearCasa();

            var panelSimple = new Panel(10);
            var panelCompuesto = new Panel(4);
            ConfigurarPanelSimple(panelSimple, casa);
            ConfigurarPanelCompuesto(panelCompuesto, casa);

            UtilConsola.Escribir("Utilizando panel simple", ConsoleColor.DarkYellow);
            UtilizarPanel(panelSimple);
            UtilConsola.Escribir("Utilizando panel compuesto", ConsoleColor.DarkYellow);
            UtilizarPanel(panelCompuesto);
        }
        private static Casa CrearCasa() {
            var casa = new Casa();
            casa.RegistrarBombillo("sala");
            casa.RegistrarBombillo("cocina");
            casa.RegistrarEquipoSonido("sala");
            casa.RegistrarTelevisor("sala");
            casa.RegistrarCortina("sala");
            return casa;
        }
        private static void ConfigurarPanelSimple(Panel panel, Casa casa) {
            var configurador = new ConfiguradorSimple(panel, casa);
            configurador.RegistrarAccionesBombillo(0, "sala");
            configurador.RegistrarAccionesBombillo(1, "cocina");
            configurador.RegistrarAccionesEquipoSonido(2, "sala",
                ConfiguradorSimple.AccionesEquipoSonido.EncenderYApagar);
            configurador.RegistrarAccionesEquipoSonido(3, "sala", ConfiguradorSimple.AccionesEquipoSonido.EmisoraYCD,
                "La W", "Mozart");
            configurador.RegistrarAccionesTelevisor(4, "sala", ConfiguradorSimple.AccionesTelevisor.EncenderYApagar);
            configurador.RegistrarAccionesTelevisor(5, "sala", ConfiguradorSimple.AccionesTelevisor.SintonizarCanales,
                "Caracol", "RCN");
            configurador.RegistrarAccionesCortina(6, "sala");
        }
        private static void ConfigurarPanelCompuesto(Panel panel, Casa casa) {
            var configurador = new ConfiguradorCompuesto(panel, casa);
            configurador.RegistrarComandoSilencio(0);
            configurador.RegistrarComandoFiesta(1);
        }
        private static void UtilizarPanel(Panel panel) {
            while (true) {
                for (int i = 0; i < panel.Nombres.Count; i++) {
                    var nombre = panel.Nombres[i];
                    Console.WriteLine("{0}:{1}", i, nombre);
                }
                var accion = UtilConsola.LeerInt("Elija botón (-1:salir) :>", -1, 10);
                if (accion == -1) return;

                UtilConsola.MostrarOpciones<Opciones>();
                var opcion = UtilConsola.LeerEnum<Opciones>("Activar/Inactivar :>");
                if (opcion == Opciones.On)
                    panel.Activar(accion);
                else
                    panel.Inactivar(accion);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}