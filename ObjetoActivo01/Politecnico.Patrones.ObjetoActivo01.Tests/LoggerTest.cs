using System;
using System.Threading;
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
                    log.Log(LoggerTask.Tipo.Informacion, "mensaje a las " + fch + " desde hilo " + i + "... tiempo= " + tiempo);
                }).Invoke();
            }
        }
    }
}