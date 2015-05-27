using System.Collections.Generic;
using System.Linq;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.MV;
using Politecnico.Patrones.ProyectoFinal.Lib.MV;
using Politecnico.Patrones.ProyectoFinal.Lib.Recursos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Reportes {
    internal class ReporteListaCanciones : ReporteBase {
        private IDictionary<string, object> _parametros;
        public ReporteListaCanciones(IGestorPersistencia gestorPersistencia)
            : base(gestorPersistencia) {
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
            var resultConsulta = _gestorPersistencia.TraerConsulta<MVCancion>(Consultas.rpt_canciones, _parametros);
            var lista = resultConsulta.ToList();

            foreach (var item in lista) {
                var interpretesCancion = _gestorPersistencia.TraerInterpretesCancion(item.Id);
                if (interpretesCancion != null) {
                    item.Interpretes =
                        interpretesCancion.Select(i => new MVInterprete {Id = i.Id, Nombre = i.Nombre}).ToList();
                }
            }

            var objeto = new MVCancionLista
                {
                    MostrarAlbum = true,
                    Canciones = lista
                };
            var result = new ReporteConsulta
                {
                    Vista = "_ReporteListaCanciones",
                    Objeto = objeto
                };
            return result;
        }
    }
}