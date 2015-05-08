﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Politecnico.Patrones.Estrategia01.Distribuciones
{
    public class DistribucionSaintLagueModificado : IAlgoritmoDistribucionCurules
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
                decimal cociente = partido.CurulesAsignadas == 1 ? 1.4m : ((2*partido.CurulesAsignadas) + 1);
                dic[partido] = (partido.VotosGanados*1m)/cociente;
                curulesAsignadas--;
            }
        }
    }
}