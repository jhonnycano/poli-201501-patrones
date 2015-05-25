using Politecnico.Patrones.ProyectoFinal.Contratos;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    internal class GestorDependencias {
        private readonly GestorPersistenciaEF _gestorPersistencia;
        public GestorDependencias() {
            _gestorPersistencia = new GestorPersistenciaEF();
        }
        public IGestorAutenticacion TraerGestorAutenticacion() {
            return new GestorAutenticacion(_gestorPersistencia);
        }
        public IGestorDominio TraerGestorDominio() {
            return new GestorDominio(_gestorPersistencia);
        }
        public IGestorPersistencia TraerGestorPersistencia() {
            return _gestorPersistencia;
        }
    }
}