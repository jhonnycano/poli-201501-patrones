using System;
using System.IO;

namespace Politecnico.Patrones.Decorador02
{
    public class CargadorDecoradores
    {
        public IDecoradorHtml CargarDesdeCadena(string origen)
        {
            IDecoradorHtml result = new DecoradorVacio();
            using (var sr = new StringReader(origen))
            {
                string def;
                while ((def = sr.ReadLine()) != null)
                {
                    IDecoradorHtml decorador = TraerDecoradorDesdeCadena(def, result);
                    result = decorador;
                }
            }
            return result;
        }

        private IDecoradorHtml TraerDecoradorDesdeCadena(string definicion, IDecoradorHtml decoradorActual)
        {
            string[] arr = definicion.Split('|');
            if (arr.Length < 1) return decoradorActual;

            string tipoNombre = "Politecnico.Patrones.Decorador02." + arr[0];
            try
            {
                Type tipo = Type.GetType(tipoNombre);
                if (tipo == null) return decoradorActual;

                IDecoradorHtml result = arr.Length == 2
                    ? (IDecoradorHtml) Activator.CreateInstance(tipo, decoradorActual, arr[1])
                    : (IDecoradorHtml) Activator.CreateInstance(tipo, decoradorActual);
                return result;
            }
            catch (Exception)
            {
                return decoradorActual;
            }
        }
    }
}