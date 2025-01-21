using SQLite;
namespace Examen_Progreso_3___202520___PCRIOLLO.Models
{
    public class Pelicula
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TituloPelicula { get; set; }
        public string Genero { get; set; }
        public string ActorPrincipal { get; set; }
        public string Awards { get; set; }
        public string Website { get; set; }

        public string NombreUsuario = "Pablo Criollo";

    }
}
