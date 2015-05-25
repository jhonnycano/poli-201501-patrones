using Ninject;
using Politecnico.Patrones.ProyectoFinal.Contratos;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public class RegistradorServiciosNinject {
        public void Registrar(IKernel kernel) {
            kernel.Bind<IGestorAutenticacion>().To<GestorAutenticacion>();
            kernel.Bind<IGestorDominio>().To<GestorDominio>();
            kernel.Bind<IGestorPersistencia>().To<GestorPersistenciaEF>();            
        }
    }
}
