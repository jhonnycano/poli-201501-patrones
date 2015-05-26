using System.Collections.Generic;

namespace Politecnico.Patrones.ProyectoFinal.Contratos {
    public interface IReporte {
        string Validar(IDictionary<string, object> parametros);
        IReporteConsulta Consultar();
    }
}