using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.MV;
using Politecnico.Patrones.ProyectoFinal.Lib.Recursos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Reportes {
    internal class ReporteDetalleInterprete : ReporteBase {
        private IDictionary<string, object> _parametros;
        private Interprete _interprete;
        public ReporteDetalleInterprete(IGestorPersistencia gestorPersistencia) : base(gestorPersistencia) {
        }
        public override string Validar(IDictionary<string, object> parametros) {
            string result = ValidarParametrosNoNull(parametros);
            if (!string.IsNullOrEmpty(result)) return result;

            if (!parametros.ContainsKey("Interprete") || parametros["Interprete"] == null) return Cadenas.rpt_val_no_interprete;

            int interpreteId;
            string interpreteEntrada = parametros["Interprete"].ToString();
            if (!int.TryParse(interpreteEntrada, out interpreteId))
                return string.Format(Cadenas.rpt_val_interprete_no_valido, interpreteEntrada);

            _interprete = _gestorPersistencia.TraerInterprete(interpreteId);
            if (_interprete == null || _interprete.Id <= 0)
                return string.Format(Cadenas.rpt_val_interprete_no_valido, interpreteEntrada);

            _parametros = parametros;
            return "";
        }
        public override IReporteConsulta Consultar() {
            IList<MVAlbum> albumes = _gestorPersistencia.TraerAlbumesInterprete(_interprete.Id);
            IList<MVAlbumDetallado> albumesDetallados = _gestorPersistencia.DetallarAlbumes(albumes);
            IList<MVCancion> canciones = _gestorPersistencia.TraerCancionesInterprete(_interprete.Id);

            var objeto = new MVInterpreteDetallado
                {
                    Id = _interprete.Id,
                    Nombre = _interprete.Nombre,
                    Albumes = new MVAlbumLista {Albumes = albumesDetallados},
                    CancionesSinAlbum = new MVCancionLista {Canciones = canciones},
                };
            var result = new ReporteConsulta
                {
                    Vista = "_ReporteDetalleInterprete",
                    Objeto = objeto
                };
            return result;
        }
    }
}