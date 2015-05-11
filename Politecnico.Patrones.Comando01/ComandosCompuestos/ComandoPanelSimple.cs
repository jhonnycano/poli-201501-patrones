using System.Collections.Generic;
using Politecnico.Patrones.Comando01.Paneles;

namespace Politecnico.Patrones.Comando01.ComandosCompuestos {
    public class ComandoPanelSimple : IComando {
        private readonly PanelSimple _panelSimple;
        private readonly IList<AccionPanelSimple> _acciones;

        public class AccionPanelSimple {
            public int Pos { get; private set; }
            public Opciones Accion { get; private set; }
            public AccionPanelSimple(int pos, Opciones accion) {
                Pos = pos;
                Accion = accion;
            }
        }
        public ComandoPanelSimple(PanelSimple panelSimple, IList<AccionPanelSimple> acciones) {
            _panelSimple = panelSimple;
            _acciones = acciones;
        }
        public void Ejecutar() {
            foreach (var accion in _acciones) {
                if (accion.Accion == Opciones.On) {
                    _panelSimple.Activar(accion.Pos);
                } else {
                    _panelSimple.Inactivar(accion.Pos);
                }
            }
            
        }
    }
}
