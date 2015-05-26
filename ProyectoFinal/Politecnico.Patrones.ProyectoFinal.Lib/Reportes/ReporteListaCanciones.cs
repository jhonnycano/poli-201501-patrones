using System;
using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Reportes {
    internal class ReporteListaCanciones : ReporteBase {
        public DateTime FchInicio { get; set; }
        public DateTime FchFin { get; set; }
        public ReporteListaCanciones(IGestorPersistencia gestorPersistencia)
            : base(gestorPersistencia)
        {
        }
        public override string Validar(IDictionary<string, object> parametros) {
            var result = ValidarParametrosNoNull(parametros);
            if (!string.IsNullOrEmpty(result)) return result;

            result = ValidarFechas(parametros);
            if (!string.IsNullOrEmpty(result)) return result;

            FchInicio = (DateTime) parametros["fch_inicio"];
            FchFin = (DateTime) parametros["fch_fin"];

            return "";
        }
        public override IReporteConsulta Consultar() {
            //_gestorPersistencia.TraerCanciones(FchInicio, FchFin);

            var result = new ReporteConsulta
                {
                    Vista = "_ReporteListaCanciones",
                    Objeto = new Object()
                };
            return result;
        }
    }
}