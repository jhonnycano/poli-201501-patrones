using Politecnico.Patrones.ProyectoFinal.Lib.VO;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    public interface IGestorAutenticacion {
        RegistrarUsuarioSalida RegistrarUsuario(RegistrarUsuarioEntrada entrada);
        IdentificarUsuarioSalida IdentificarUsuario(IdentificarUsuarioEntrada entrada);
        ModificarUsuarioSalida ModificarUsuario(ModificarUsuarioEntrada entrada);
    }
}