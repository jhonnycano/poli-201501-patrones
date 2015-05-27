using Newtonsoft.Json;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.MV {
    public class MVInterprete {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Nombre { get; set; }
    }
}