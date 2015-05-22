using System;
using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Web.Models {
    public class MVListaInterpretes {
        public bool Editable { get; set; }
        public int PadreId { get; set; }
        public string Controlador { get; set; }
        public string AccionAgregar { get; set; }
        public IList<Tuple<string, string>> AccionesEditar { get; set; }
        public IEnumerable<MVInterprete> ListaInterpretes { get; set; }
        public MVListaInterpretes()
        {
           AccionesEditar = new List<Tuple<string, string>>();
        }
    }
}