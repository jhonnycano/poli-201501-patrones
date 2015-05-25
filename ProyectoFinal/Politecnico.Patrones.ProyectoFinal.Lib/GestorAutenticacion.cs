using System;
using System.Security.Cryptography;
using System.Text;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;

namespace Politecnico.Patrones.ProyectoFinal.Lib {
    internal class GestorAutenticacion : IGestorAutenticacion {
        private const string Llave =
            "v+syPHmxRUcsdrOLB+BLJn2N71l6teWoYun5iR22P0wwEOoQtre2eZIFerY9isde4/E70W4uk4ws6HrCax8NCA==";
        private readonly IGestorPersistencia _gestorPersistencia;

        public GestorAutenticacion(IGestorPersistencia gestorPersistencia) {
            _gestorPersistencia = gestorPersistencia;
        }

        public RegistrarUsuarioSalida RegistrarUsuario(RegistrarUsuarioEntrada entrada) {
            var salida = new RegistrarUsuarioSalida();

            if (entrada.Clave != entrada.ClaveRepetida) {
                return SalidaBase.Fallo(salida, "La clave no coincide, por favor verifique");
            }

            var usuario = _gestorPersistencia.TraerUsuario(entrada.Correo);
            if (usuario != null)
                return SalidaBase.Fallo(salida, "Usuario con correo " + entrada.Correo + " ya está registrado");

            var claveHash = TraerHash(entrada.Clave);
            usuario = new Usuario {Nombre = entrada.Nombre, Correo = entrada.Correo, Clave = claveHash};
            _gestorPersistencia.Guardar(usuario);

            return SalidaBase.Exito(salida);
        }
        public IdentificarUsuarioSalida IdentificarUsuario(IdentificarUsuarioEntrada entrada) {
            var salida = new IdentificarUsuarioSalida();

            var claveHash = TraerHash(entrada.Clave);
            var usuario = _gestorPersistencia.TraerUsuario(entrada.Correo, claveHash);

            if (usuario == null) return SalidaBase.Fallo(salida, "Autenticación fallida");
            salida.Usuario = usuario;

            return SalidaBase.Exito(salida);
        }
        public ModificarUsuarioSalida ModificarUsuario(ModificarUsuarioEntrada entrada) {
            var salida = new ModificarUsuarioSalida();
            return SalidaBase.Fallo(salida, "No implementado");
        }
        public Usuario TraerUsuario(string correo) {
            return _gestorPersistencia.TraerUsuario(correo);
        }

        private string TraerHash(string entrada) {
            var algo = HMAC.Create("HMACMD5");
            algo.Key = Convert.FromBase64String(Llave);
            var bufferEntrada = Encoding.UTF8.GetBytes(entrada);
            var bufferSalida = algo.ComputeHash(bufferEntrada);
            var result = Convert.ToBase64String(bufferSalida);
            return result;
        }
    }
}