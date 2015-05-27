using System.Collections.Generic;
using System.Linq;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Lib.MV;
using Politecnico.Patrones.ProyectoFinal.Lib.Recursos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Reportes {
    internal class ReporteListaAlbumes : ReporteBase {
        private IDictionary<string, object> _parametros;
        public ReporteListaAlbumes(IGestorPersistencia gestorPersistencia) : base(gestorPersistencia) {
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
            var resultConsulta = _gestorPersistencia.TraerConsulta<MVAlbumDetallado>(Consultas.rpt_albumes, _parametros);
            var lista = resultConsulta.ToList();

            foreach (var item in lista) {
                // interpretes de album
                var interpretesAlbum = _gestorPersistencia.TraerInterpretesAlbum(item.Id);
                if (interpretesAlbum != null) {
                    item.Interpretes =
                        interpretesAlbum.Select(i => new MVInterprete {Id = i.Id, Nombre = i.Nombre}).ToList();
                }
                
                // canciones de album
                var cancionesAlbum = _gestorPersistencia.TraerCancionesAlbum(item.Id);
                if (cancionesAlbum != null) {
                    item.Canciones =
                        cancionesAlbum.Select(i => new MVCancion {Id = i.Id, Nombre = i.Nombre}).ToList();
                }
            }

            var result = new MVAlbumLista
                {
                    Vista = "_ReporteListaAlbumes",
                    Objeto = lista
                };
            return result;
        }
    }
}