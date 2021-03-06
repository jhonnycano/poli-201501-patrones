﻿using System;
using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos.MV;

namespace Politecnico.Patrones.ProyectoFinal.Web.Models {
    public class MVListaInterpretes {
        public bool Editable { get; set; }
        public int PadreId { get; set; }
        public string Controlador { get; set; }
        public IList<Tuple<string, string>> AccionesEditar { get; set; }
        public IEnumerable<MVInterprete> ListaInterpretes { get; set; }
        public bool EnviarTokenVerificacion { get; set; }
        public MVListaInterpretes()
        {
            AccionesEditar = new List<Tuple<string, string>>();
            EnviarTokenVerificacion = true;
        }
    }
}