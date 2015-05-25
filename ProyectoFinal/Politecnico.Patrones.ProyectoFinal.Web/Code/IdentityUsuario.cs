using System;
using System.Security.Principal;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Web {
    [Serializable]
    public class IdentityUsuario : IIdentity {
        private readonly IIdentity _identity;
        private readonly Usuario _usuario;
        public IdentityUsuario(IIdentity identity, Usuario usuario) {
            _identity = identity;
            _usuario = usuario;
        }
        public int Id {
            get { return _usuario == null ? 0 : _usuario.Id; }
        }
        public string Name {
            get { return _identity.Name; }
        }
        public string AuthenticationType {
            get { return _identity.AuthenticationType; }
        }
        public bool IsAuthenticated {
            get { return _identity.IsAuthenticated; }
        }
        public string Nombre { get { return _usuario.Nombre; }}
        public string Correo { get { return _usuario.Correo; }}
    }
}