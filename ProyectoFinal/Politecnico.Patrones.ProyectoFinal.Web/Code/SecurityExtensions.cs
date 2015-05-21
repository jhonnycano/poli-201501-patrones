using System.Security.Principal;

namespace Politecnico.Patrones.ProyectoFinal.Web {
    public static class SecurityExtentions {
        public static PrincipalUsuario APrincipalUsuario(this IPrincipal principal) {
            return (PrincipalUsuario) principal;
        }
    }
}