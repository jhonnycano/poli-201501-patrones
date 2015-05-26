﻿using System.Collections.Generic;
using System.Linq;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Lib.MV;
using Politecnico.Patrones.ProyectoFinal.Lib.Recursos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Reportes {
    internal class ReporteListaCanciones : ReporteBase {
        private IDictionary<string, object> _parametros;
        public ReporteListaCanciones(IGestorPersistencia gestorPersistencia)
            : base(gestorPersistencia)
        {
        }
        public override string Validar(IDictionary<string, object> parametros) {
            var result = ValidarParametrosNoNull(parametros);
            if (!string.IsNullOrEmpty(result)) return result;

            result = ValidarFechas(parametros);
            if (!string.IsNullOrEmpty(result)) return result;

            _parametros = parametros;
            return "";
        }
        public override IReporteConsulta Consultar() {
            var resultConsulta = _gestorPersistencia.TraerConsulta<MVCancionLista.Item>(Cadenas.sql_rpt_canciones, _parametros);
            var lista = resultConsulta.ToList();

            var result = new MVCancionLista
                {
                    Vista = "_ReporteListaCanciones",
                    Objeto = lista
                };
            return result;
        }

    }
}