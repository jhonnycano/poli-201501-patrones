﻿using System.Collections.Generic;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Contratos {
    public interface IGestorPersistencia {
        Usuario TraerUsuario(string correo);
        Usuario TraerUsuario(string correo, string clave);

        Interprete TraerInterprete(int id);
        IList<Interprete> TraerInterpretes(int pagina, string filtroNombre);
        IList<Interprete> TraerInterpretesAlbum(int albumId);
        IList<Interprete> TraerInterpretesCancion(int cancionId);
        Cancion TraerCancion(int id);
        IList<Cancion> TraerCanciones(int pagina, string filtroNombre);
        Album TraerAlbum(int id);
        IList<Album> TraerAlbumes(int pagina, string filtroNombre);
        CancionInterprete TraerCancionInterprete(int cancionId, int interpreteId);
        AlbumInterprete TraerAlbumInterprete(int albumId, int interpreteId);

        VotableUsuario TraerVotableUsuario(int votableId, int usuarioId);

        void Guardar(Interprete entidad);
        void Guardar(Cancion entidad);
        void Guardar(CancionInterprete cancionInterprete);
        void Guardar(Album album);
        void Guardar(AlbumInterprete albumInterprete);
        void Guardar(Votable votable);
        void Guardar(VotableUsuario votableUsuario);
        void Guardar(Usuario usuario);

        void EliminarCancionInterprete(int interprete, int cancion);
        void EliminarAlbumInterprete(int interprete, int album);
    }
}