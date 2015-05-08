using System;
using System.Collections.Generic;
using Politecnico.Comunes;

namespace Politecnico.Patrones.Estrategia01.Consola
{
    class Inicio
    {
        static void Main()
        {
            UtilConsola.MostrarOpciones<FabricaDistribucion.AlgoritmoDistribucion>();
            var tipoAlgoritmo = UtilConsola.LeerEnum<FabricaDistribucion.AlgoritmoDistribucion>();

            var curules = UtilConsola.LeerInt("Cuantas curules disponibles (max:1000) ? ", 0, 1000);

            var partidos = LeerPartidos();
            if (partidos.Count == 0)
            {
                Console.WriteLine("Ingrese la lista");
                return;
            }

            var f = new FabricaDistribucion();
            var algoritmo = f.TraerAlgoritmo(tipoAlgoritmo);
            algoritmo.Calcular(partidos, curules);

            MostrarResultado(partidos);
            UtilConsola.Pausa();
        }

        private static IList<InfoPartido> LeerPartidos()
        {
            IList<InfoPartido> result = new List<InfoPartido>();
            while (true)
            {
                var partidoNombre = UtilConsola.LeerString("Nombre del partido a ingresar (vacio para salir) ");
                if (String.IsNullOrEmpty(partidoNombre)) break;

                var votos = UtilConsola.LeerInt("Votos ganados de este partido  (max:1000000000):", 0, 1000000000);
                var infoPartido = new InfoPartido {Nombre = partidoNombre, VotosGanados = votos};
                result.Add(infoPartido);
            }
            return result;
        }

        private static void MostrarResultado(IEnumerable<InfoPartido> partidos)
        {
            UtilConsola.Escribir("RESULTADOS", ConsoleColor.Green);

            foreach (var infoPartido in partidos)
            {
                UtilConsola.Escribir(infoPartido.Nombre, ConsoleColor.Yellow);
                Console.WriteLine("\tCon votos={0,10} queda con curules={1,4}", infoPartido.VotosGanados, infoPartido.CurulesAsignadas);
            }
        }
    }
}
