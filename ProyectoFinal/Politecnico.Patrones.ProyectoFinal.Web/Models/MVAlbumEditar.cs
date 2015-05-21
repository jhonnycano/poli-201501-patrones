using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Web.Models
{
    public class MVAlbumEditar
    {
        public Album Album { get; set; }
        public IList<Interprete> ListaInterpretes { get; set; }
        public int Interprete { get; set; }
    }
}