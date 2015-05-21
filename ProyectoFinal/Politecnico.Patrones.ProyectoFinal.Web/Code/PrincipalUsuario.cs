using System.Security.Principal;

namespace Politecnico.Patrones.ProyectoFinal.Web {
    public class PrincipalUsuario : IPrincipal {
        private readonly IdentityUsuario _identity;
        public PrincipalUsuario(IdentityUsuario identity) {
            _identity = identity;
        }
        public bool IsInRole(string role) {
            return false;
        }
        public IIdentity Identity {
            get { return _identity; }
        }
        public IdentityUsuario IdentityUsuario {
            get { return _identity; }
        }
    }
}