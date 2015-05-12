using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Politecnico.Patrones.ObjetoActivo01
{
    public class Logger : ILogger, IDisposable {
        private readonly string _ruta;
        private readonly Queue<LogInfo> _cola;
        private readonly ThreadStart _tarea;
        private bool _salir;
        public Logger(string ruta) {
            _ruta = ruta;
            _cola = new Queue<LogInfo>();
            _salir = false;
            _tarea = new ThreadStart(Target);
            _tarea.BeginInvoke(Algo, null);
        }
        public void Log(LoggerTask.Tipo tipo, string msj) {
            lock (_cola) {
                _cola.Enqueue(new LogInfo
                    {
                        Fecha = DateTime.Now,
                        Tipo = tipo,
                        Mensaje = msj
                    });
            }
        }
        private void Target() {
            while (true) {
                if (_salir) return;
                lock (_cola) {
                    while (_cola.Count > 0) {
                        var itm = _cola.Dequeue();
                        HacerLog(itm);
                    }
                }
            }
        }
        private void Algo(IAsyncResult ar)
        {

        }
        private void HacerLog(LogInfo info)
        {
            File.AppendAllText(_ruta,
                info.Fecha.ToString("yyyy-MM-dd HH:mm:ss.fffff") + " " +
                info.Tipo + "\t" + info.Mensaje +
                Environment.NewLine);
        }

        public void Dispose() {
            _salir = true;
        }
    }
}
