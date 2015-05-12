using System;

namespace Politecnico.Patrones.ObjetoActivo01 {
    public struct LogInfo {
        public DateTime Fecha { get; set; }
        public LoggerTask.Tipo Tipo { get; set; }
        public string Mensaje { get; set; }
    }
}