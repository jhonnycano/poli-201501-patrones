using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.MV;
using Politecnico.Patrones.ProyectoFinal.Lib.Recursos;

namespace Politecnico.Patrones.ProyectoFinal.Lib.Reportes {
    internal class ReporteListaCancionesAlbum : ReporteBase {
        private Album _album;
        public ReporteListaCancionesAlbum(IGestorPersistencia gestorPersistencia) : base(gestorPersistencia) {
        }
        public override string Validar(IDictionary<string, object> parametros) {
            string result = ValidarParametrosNoNull(parametros);
            if (!string.IsNullOrEmpty(result)) return result;

            if (!parametros.ContainsKey("Album") || parametros["Album"] == null) return Cadenas.rpt_val_no_album;

            int albumId;
            string albumEntrada = parametros["Album"].ToString();
            if (!int.TryParse(albumEntrada, out albumId))
                return string.Format(Cadenas.rpt_val_album_no_valido, albumEntrada);

            _album = _gestorPersistencia.TraerAlbum(albumId);
            if (_album == null || _album.Id <= 0)
                return string.Format(Cadenas.rpt_val_album_no_valido, albumEntrada);

            return "";
        }
        public override IReporteConsulta Consultar() {
            IList<MVAlbumDetallado> albumesDetallados =
                _gestorPersistencia.DetallarAlbumes(new List<MVAlbum> {new MVAlbum(_album)});

            var album = albumesDetallados[0];
            var result = new ReporteConsulta
            {
                Vista = "_ReporteListaCancionesAlbum",
                Objeto = album
            };
            return result;
        }
    }
}