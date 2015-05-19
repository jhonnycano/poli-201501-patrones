using Politecnico.Patrones.ProyectoFinal.Lib.VO;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public interface IGestorAutenticacion {
        RegistrarUsuarioSalida RegistrarUsuario(RegistrarUsuarioEntrada entrada);
        IdentificarUsuarioSalida RegistrarUsuario(IdentificarUsuarioEntrada entrada);
        ModificarUsuarioSalida RegistrarUsuario(ModificarUsuarioEntrada entrada);
    }
}