using System.ComponentModel;
using Newtonsoft.Json;

namespace Politecnico.Patrones.ProyectoFinal.Lib.MV {
    public class MVInterprete {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Nombre { get; set; }
    }
}