using System;
using System.Collections.Generic;

namespace Politecnico.Patrones.ObjetoActivo01 {
    public static class Util {
        public static IList<Trabajo> GenerarTrabajos(int cantidad, int pesoMaximo = 1000, int cantidadMaxima = 10) {
            IList<Trabajo> result = new List<Trabajo>();
            var rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < cantidad; i++) {
                result.Add(new Trabajo
                    {
                        Id = Guid.NewGuid(),
                        Peso = rnd.Next(pesoMaximo),
                        Cantidad = rnd.Next(cantidadMaxima)
                    });
            }
            return result;
        }
    }
}
