﻿#region
using Politecnico.Patrones.Comando01.Perifericos;

#endregion

namespace Politecnico.Patrones.Comando01.ComandosSimples {
    public class ComandoEjecutarCDEquipo : IComando {
        private readonly string _cd;
        private readonly EquipoSonido _equipoSonido;
        public ComandoEjecutarCDEquipo(EquipoSonido equipoSonido, string cd) {
            _equipoSonido = equipoSonido;
            _cd = cd;
        }
        public void Ejecutar() {
            _equipoSonido.ExtraerCD();
            _equipoSonido.InsertarCD(_cd);
        }
    }
}