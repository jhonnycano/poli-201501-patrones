namespace Politecnico.Patrones.Decorador02
{
    public class DecoradorVacio : IDecoradorHtml
    {
        public string Decorar(string entrada)
        {
            return entrada;
        }
    }
}
