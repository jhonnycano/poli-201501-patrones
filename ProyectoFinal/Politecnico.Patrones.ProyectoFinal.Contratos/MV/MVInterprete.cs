using Newtonsoft.Json;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Contratos.MV {
    public class MVInterprete {
        public MVInterprete() {
        }
        public MVInterprete(Interprete interprete) {
            Id = interprete.Id;
            Nombre = interprete.Nombre;
        }
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Nombre { get; set; }
    }
}