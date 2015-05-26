using System;
using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Reportes {
    internal class ReporteListaCanciones : ReporteBase {
        public override string Validar(IDictionary<string, object> parametros) {
            var tmp = ValidarFechas(parametros);
            if (!string.IsNullOrEmpty(tmp)) return tmp;

            return "";
        }
        public override IReporteConsulta Consultar() {
            
            
            var result = new ReporteConsulta
                {
                    Vista = "_ReporteListaCanciones",
                    Objeto = new Object()
                };
            return result;
        }
    }
}