using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Politecnico.Patrones.ObjetoActivo01.Tests {
    [TestFixture]
    public class LoggerTest {
        [Test]
        public void LoggerTask_Simple() {
            var log = new LoggerTask(@"D:\AreaTrabajo\log.txt");
            log.Log(LoggerTask.Tipo.Informacion, "algun mensaje");
        }

        [Test]
        public void LoggerTask_Concurrente() {
            var log = new LoggerTask(@"D:\AreaTrabajo\log.txt");
            var rnd = new Random();

            for (int i = 0; i < 100; i++) {
                /*
                ThreadPool.QueueUserWorkItem(c => {
                    //Contexto contexto = (Contexto) c;
                    var fch = DateTime.Now.ToString("HH:mm:ss.fffff");
                    Thread.Sleep(rnd.Next(10));
                    log.Log(LoggerTask.Tipo.Informacion, "mensaje a las " + fch + " desde hilo " + i);
                }, ctx);
                 * */
                new ThreadStart(() => {
                    var fch = DateTime.Now.ToString("HH:mm:ss.fffff");
                    Thread.Sleep(rnd.Next(100));
                    log.Log(LoggerTask.Tipo.Informacion, "mensaje a las " + fch + " desde hilo " + i);
                }).Invoke();
            }
        }

        [Test]
        public void Logger_Simple() {
            var log = new Logger(@"D:\AreaTrabajo\log.txt");
            log.Log(LoggerTask.Tipo.Informacion, "algun mensaje");
        }

        [Test]
        public void Logger_Concurrente() {
            var log = new Logger(@"D:\AreaTrabajo\log.txt");
            var rnd = new Random();

            for (int i = 0; i < 100; i++) {
                /*
                ThreadPool.QueueUserWorkItem(c => {
                    //Contexto contexto = (Contexto) c;
                    var fch = DateTime.Now.ToString("HH:mm:ss.fffff");
                    Thread.Sleep(rnd.Next(10));
                    log.Log(LoggerTask.Tipo.Informacion, "mensaje a las " + fch + " desde hilo " + i);
                }, ctx);
                 * */
                new ThreadStart(() => {
                    var fch = DateTime.Now.ToString("HH:mm:ss.fffff");
                    var tiempo = rnd.Next(100);
                    Thread.Sleep(tiempo);
                    log.Log(LoggerTask.Tipo.Informacion,
                        "mensaje a las " + fch + " desde hilo " + i + "... tiempo= " + tiempo);
                }).Invoke();
            }
        }

        [Test]
        public void Logger_TrabajosPredefinidos() {
            var trabajos = Util.GenerarTrabajos(3);
            var log = new Logger(@"D:\AreaTrabajo\log.txt");
            Action<Trabajo> miAccion = t => {
                    for (int i = 0; i < t.Cantidad; i++) {
                        log.Log(LoggerTask.Tipo.Informacion, string.Format("Trabajo {0} paso {1} inicia", t.Id, i));
                        Thread.Sleep(t.Peso);
                        log.Log(LoggerTask.Tipo.Informacion, string.Format("Trabajo {0} paso {1} termina", t.Id, i));
                    }
            };

            var tareas = (from trabajo in trabajos select Task.Run(() => miAccion(trabajo))).ToArray();

            // esperar finalización de tareas
            Task.WaitAll(tareas);
        }
    }
}