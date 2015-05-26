using System;
using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Lib.Reportes;

namespace Politecnico.Patrones.ProyectoFinal.Lib.MV {
    public class MVCancionLista : ReporteConsulta {
        public class Item {
            public int Id { get; set; }
            public DateTime FchCreacion { get; set; }
            public string Nombre { get; set; }
            public string Album { get; set; }
            public int TotalVotos { get; set; }
        }

        public override object Objeto {
            get { return Items; }
            set { Items = (IList<Item>) value; }
        }
        public IList<Item> Items { get; set; }
    }
}