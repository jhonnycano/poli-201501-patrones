using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Politecnico.Patrones.Iterador.DivisionTrabajo;

namespace Tests.Iterador.DivisionTrabajo
{
    [TestFixture]
    public class DivisionTrabajoTest
    {
        [Test]
        public void Simple()
        {
            IElemento estructura = UtilDivisionTrabajo.CrearEstructura();
            IEnumerator<IElemento> it = estructura.GetEnumerator();
            var sb = new StringBuilder();
            while (it.MoveNext())
            {
                sb.AppendLine(it.Current.TraerResumen());
            }
            Console.WriteLine(sb.ToString());
        }
    }
}