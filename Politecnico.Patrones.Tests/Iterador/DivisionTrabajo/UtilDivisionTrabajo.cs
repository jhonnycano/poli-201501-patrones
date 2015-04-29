using System;
using Newtonsoft.Json.Linq;
using Politecnico.Patrones.Iterador.DivisionTrabajo;
using Tests.Recursos;

namespace Tests.Iterador.DivisionTrabajo
{
    public static class UtilDivisionTrabajo
    {
        public static IElemento CrearEstructura()
        {
            IElemento result = LeerElemento(JObject.Parse(Archivos.Proyecto2));
            return result;
        }

        private static IElemento LeerElemento(JObject obj)
        {
            var nombre = obj.Value<string>("nombre");
            JToken token;
            if (obj.TryGetValue("porcentaje", out token))
            {
                var porcentaje = token.Value<decimal>();
                return new Tarea {Nombre = nombre, PorcentajeCompletado = porcentaje};
            }
            if (obj.TryGetValue("tareas", out token))
            {
                var grupoTarea = new GrupoTarea {Nombre = nombre};
                foreach (JToken tkTarea in token)
                {
                    IElemento elem = LeerElemento(tkTarea as JObject);
                    grupoTarea.Elementos.Add(elem);
                }
                return grupoTarea;
            }

            throw new NotSupportedException("elemento desconocido");
        }
    }
}