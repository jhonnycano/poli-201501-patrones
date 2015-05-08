using System;
using System.Collections.Generic;
using System.Linq;

namespace Politecnico.Patrones.Estrategia01.Distribuciones
{
    public class DistribucionHondt : IAlgoritmoDistribucionCurules
    {
        public void Calcular(IList<InfoPartido> partidos, int curulesDisponibles)
        {
            if (curulesDisponibles < 1)
                throw new ArgumentException("No hay curules suficientes para realizar el cálculo");

            var curulesAsignadas = curulesDisponibles;
            var dic = partidos.ToDictionary(k => k, v => v.VotosGanados * 1.0m);
            while (curulesAsignadas > 0)
            {
                // buscar el mayor
                var m = (from itm in dic orderby itm.Value descending select itm).ToList();

                // asignar curul
                var partido = m[0].Key;
                partido.CurulesAsignadas = partido.CurulesAsignadas + 1;

                // decrementar indice y curules pendientes
                dic[partido] = (partido.VotosGanados * 1m) / ((partido.CurulesAsignadas) + 1);
                curulesAsignadas--;
            }

            /*
            var dic = new Dictionary<int, Dictionary<InfoPartido, decimal>>();
            for (int i = 1; i <= curulesDisponibles; i++)
            {
                dic.Add(i, new Dictionary<InfoPartido, decimal>());
                Dictionary<InfoPartido, decimal> elem = dic[i];
                foreach (InfoPartido infoPartido in partidos)
                {
                    decimal coeficiente = infoPartido.VotosGanados / (i * 1.0m);
                    elem.Add(infoPartido, coeficiente);
                }
            }
            var q = (from i in dic
                from d in i.Value
                orderby d.Value descending
                select new {Partido = d.Key, Peso = d.Value}).ToList();

            int curulesAsignadas = curulesDisponibles;
            foreach (var itm in q)
            {
                itm.Partido.CurulesAsignadas = itm.Partido.CurulesAsignadas + 1;
                curulesAsignadas--;
                if (curulesAsignadas <= 0) break;
            }
             */
        }
    }
}