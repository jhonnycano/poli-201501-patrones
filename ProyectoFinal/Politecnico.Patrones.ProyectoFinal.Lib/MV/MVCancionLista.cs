using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Lib.Reportes;

namespace Politecnico.Patrones.ProyectoFinal.Lib.MV {
    public class MVCancionLista : ReporteConsulta {
        public override object Objeto {
            get { return Items; }
            set { Items = (IList<MVCancion>)value; }
        }
        public IList<MVCancion> Items { get; set; }
    }
}