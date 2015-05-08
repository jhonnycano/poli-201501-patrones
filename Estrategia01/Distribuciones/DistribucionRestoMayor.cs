using System;
using System.Collections.Generic;
using System.Linq;

namespace Politecnico.Patrones.Estrategia01.Distribuciones
{
    public enum MetodoDistribucion
    {
        Hare,
        Droop,
        Imperiali
    }

    public class DistribucionRestoMayor : IAlgoritmoDistribucionCurules
    {
        private readonly MetodoDistribucion _metodo;

        public DistribucionRestoMayor(MetodoDistribucion metodo)
        {
            _metodo = metodo;
        }

        public MetodoDistribucion Metodo
        {
            get { return _metodo; }
        }

        public void Calcular(IList<InfoPartido> partidos, int curulesDisponibles)
        {
            if (curulesDisponibles < 1)
                throw new ArgumentException("No hay curules suficientes para realizar el cálculo");

            // calcular cociente
            int totalVotos = partidos.Sum(p => p.VotosGanados);
            int cociente = CalcularCociente(curulesDisponibles, totalVotos);

            int curulesAsignadas = curulesDisponibles;
            // asignar curules por cociente
            foreach (InfoPartido infoPartido in partidos)
            {
                int curulesAAsignar = infoPartido.VotosGanados/cociente;
                infoPartido.CurulesAsignadas += curulesAAsignar;
                curulesAsignadas -= curulesAAsignar;
            }
            // asignar curules por residuo

            var listaResiduo =
                partidos
                    .Select(p => new {Partido = p, Residuo = p.VotosGanados - (p.CurulesAsignadas*cociente)})
                    .OrderByDescending(i => i.Residuo)
                    .ToList();

            int ind = 0;
            while (curulesAsignadas > 0)
            {
                listaResiduo[ind].Partido.CurulesAsignadas++;
                ind++;
                curulesAsignadas--;
            }
        }

        private int CalcularCociente(int curulesDisponibles, int totalVotos)
        {
            switch (_metodo)
            {
                case MetodoDistribucion.Hare: return totalVotos / curulesDisponibles;
                case MetodoDistribucion.Droop: return 1 + (totalVotos / (curulesDisponibles + 1));
                case MetodoDistribucion.Imperiali: return totalVotos / (curulesDisponibles + 2);
                default: throw new ApplicationException("Metodo de cociente no conocido");
            }
        }
    }
}