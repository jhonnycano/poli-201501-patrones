using System;
using System.IO;
using System.Threading.Tasks;

namespace Politecnico.Patrones.ObjetoActivo01 {
    public interface ILogger {
        void Log(LoggerTask.Tipo tipo, string msj);
    }

    public class LoggerTask : ILogger {
        private readonly string _ruta;

        public enum Tipo {
            Informacion,
            Advertencia,
            Error,
        }

        public LoggerTask(string ruta) {
            _ruta = ruta;
        }

        public void Log(Tipo tipo, string msj) {
            Task.Run(() => GrabarLog(new LogInfo {Fecha = DateTime.Now, Tipo = tipo, Mensaje = msj}));
        }

        internal async Task GrabarLog(LogInfo info) {
            await Task.Run(() => File.AppendAllText(_ruta,
                info.Fecha.ToString("yyyy-MM-dd HH:mm:ss.fffff") + " " + 
                info.Tipo + "\t" + info.Mensaje +
                Environment.NewLine));
        }
    }
}