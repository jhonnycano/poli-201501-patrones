using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Web.Models {
    public class Paginador {
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public int PaginaAnterior { get; set; }
        public int PaginaSiguiente { get; set; }
        public bool PaginaSiguienteActiva { get; set; }
        public bool PaginaAnteriorActiva { get; set; }
        public IDictionary<string, string> Parametros { get; set; }
    }
}