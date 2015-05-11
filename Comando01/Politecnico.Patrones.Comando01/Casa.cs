#region
using System.Collections.Generic;
using Politecnico.Patrones.Comando01.Perifericos;

#endregion

namespace Politecnico.Patrones.Comando01 {
    /// <summary>
    ///     Por ahora son propiedades del objeto, más adelante podría pensarse en colecciones de objetos
    /// </summary>
    public class Casa {
        public IDictionary<string, Bombillo> Bombillos { get; set; }
        public IDictionary<string, EquipoSonido> EquiposSonido { get; set; }
        public IDictionary<string, Televisor> Televisores { get; set; }
        public IDictionary<string, Cortina> Cortinas { get; set; }
        public Casa() {
            Bombillos = new Dictionary<string, Bombillo>();
            EquiposSonido = new Dictionary<string, EquipoSonido>();
            Televisores = new Dictionary<string, Televisor>();
            Cortinas = new Dictionary<string, Cortina>();
        }
        public Bombillo RegistrarBombillo(string nombre) {
            var bombillo = new Bombillo(nombre);
            Bombillos[nombre] = bombillo;
            return bombillo;
        }
        public EquipoSonido RegistrarEquipoSonido(string nombre) {
            var equipoSonido = new EquipoSonido(nombre);
            EquiposSonido[nombre] = equipoSonido;
            return equipoSonido;
        }
        public Televisor RegistrarTelevisor(string nombre) {
            var televisor = new Televisor(nombre);
            Televisores[nombre] = televisor;
            return televisor;
        }
        public Cortina RegistrarCortina(string nombre) {
            var cortina = new Cortina(nombre);
            Cortinas[nombre] = cortina;
            return cortina;
        }
    }
}