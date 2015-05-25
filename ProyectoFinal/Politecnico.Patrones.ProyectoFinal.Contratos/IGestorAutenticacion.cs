using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;

namespace Politecnico.Patrones.ProyectoFinal.Contratos {
    public interface IGestorAutenticacion {
        RegistrarUsuarioSalida RegistrarUsuario(RegistrarUsuarioEntrada entrada);
        IdentificarUsuarioSalida IdentificarUsuario(IdentificarUsuarioEntrada entrada);
        ModificarUsuarioSalida ModificarUsuario(ModificarUsuarioEntrada entrada);
        Usuario TraerUsuario(string correo);
    }
}