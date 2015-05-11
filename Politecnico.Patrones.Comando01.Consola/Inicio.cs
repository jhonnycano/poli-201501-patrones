#region
using Politecnico.Comunes;
using Politecnico.Patrones.Comando01.Paneles;

#endregion

namespace Politecnico.Patrones.Comando01.Consola {
    public class Inicio {
        public static void Main(string[] args) {
            var casa = CrearCasa();

            var panel = new PanelSimple(10);
            ConfigurarPanelSimple(panel, casa);
            UtilizarPanelSimple(panel);
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
        private static void ConfigurarPanelSimple(PanelSimple panel, Casa casa) {
            var configuradorPanelSimple = new ConfiguradorPanelSimple(panel, casa);
            configuradorPanelSimple.RegistrarAccionesBombillo(0, "sala");
            configuradorPanelSimple.RegistrarAccionesBombillo(1, "cocina");
            configuradorPanelSimple.RegistrarAccionesEquipoSonido(2, "sala", ConfiguradorPanelSimple.AccionesEquipoSonido.EncenderYApagar);
            configuradorPanelSimple.RegistrarAccionesEquipoSonido(3, "sala", ConfiguradorPanelSimple.AccionesEquipoSonido.EmisoraYCD, "La W", "Mozart");
            configuradorPanelSimple.RegistrarAccionesTelevisor(4, "sala", ConfiguradorPanelSimple.AccionesTelevisor.EncenderYApagar);
            configuradorPanelSimple.RegistrarAccionesTelevisor(5, "sala", ConfiguradorPanelSimple.AccionesTelevisor.SintonizarCanales, "Caracol", "RCN");
            configuradorPanelSimple.RegistrarAccionesCortina(6, "sala");
        }
        private static void UtilizarPanelSimple(PanelSimple panel) {
            while (true) {
                var accion = UtilConsola.LeerInt("Elija botón (0:salir) :>", 0, 10);
                if (accion == 0) return;

                UtilConsola.MostrarOpciones<Opciones>();
                var opcion = UtilConsola.LeerEnum<Opciones>("Activar/Inactivar :>");
                if (opcion == Opciones.On)
                    panel.Activar(accion);
                else
                    panel.Inactivar(accion);
            }
        }
    }
}