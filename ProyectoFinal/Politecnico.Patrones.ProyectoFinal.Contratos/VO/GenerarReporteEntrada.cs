using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.VO {
    public enum TipoReporte { ListaCanciones, ListaAlbumes, ListaInterpretes, ListaCancionesAlbum }

    public class GenerarReporteEntrada {
        public IDictionary<string, object> Parametros { get; set; }
        public TipoReporte Tipo { get; set; }
    }
}