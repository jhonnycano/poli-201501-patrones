using System;

namespace Politecnico.Patrones.Decorador01.Consola
{
    internal class Inicio
    {
        private static void Main() {
            Console.Write(@"Ingrese cadena: ");
            var entrada = Console.ReadLine();

            var decoradores = PrepararDecoradores();
            string result = decoradores.Decorar(entrada);
            Console.WriteLine(result);
            Console.ReadKey();
        }
        private static DecoradorBarraHorizontalDespues PrepararDecoradores() {
            return new DecoradorBarraHorizontalDespues(
                new DecoradorFuenteHtml4(
                    new DecoradorAcentos(
                        new DecoradorSubrayado(
                            new DecoradorCursiva(
                                new DecoradorNegrilla()
                                )
                            )
                        ),
                    new DecoradorFuenteHtml4.Parametros {Color = "#f0f0e0", Tam = "16px", Tipo = "Times New Roman"})
                );
        }
    }
}