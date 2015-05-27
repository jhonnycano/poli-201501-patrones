namespace Politecnico.Patrones.ProyectoFinal.Contratos.Entidades {
    public interface ICancion {
        int Id { get; set; }
        string Nombre { get; set; }
        int VotableId { get; set; }
        int? AlbumId { get; set; }
        string Album { get; set; }
    }
}