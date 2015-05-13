using System;
using System.Collections.Generic;
using System.IO;

namespace Politecnico.Patrones.Estrategia01 {
    public static class UtilInfo {
        public static IList<InfoPartido> TraerInfoPartidos(string data) {
            using (var sr = new StringReader(data)) {
                string linea;
                var result = new List<InfoPartido>();
                while ((linea = sr.ReadLine()) != null) {
                    while (linea.IndexOf("  ", StringComparison.Ordinal) >= 0) linea = linea.Replace("  ", " ");
                    linea = linea.Replace(" ", "\t");
                    string[] arr = linea.Split('\t');
                    if (arr.Length < 2) continue;

                    var infoPartido = new InfoPartido {Nombre = arr[0], VotosGanados = int.Parse(arr[1])};
                    result.Add(infoPartido);
                }
                return result;
            }
        }
    }
}