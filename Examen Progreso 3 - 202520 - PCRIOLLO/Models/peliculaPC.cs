using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Progreso_3___202520___PCRIOLLO.Models
{
    public class peliculaPC
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string TituloPelicula { get; set; }
        public string GeneroPelicula { get; set; }
        public string Actores { get; set; }
        public string Premios { get; set; }
        public string SitioWeb { get; set; }
        public string nombreEs = "PCriollo";


    }
}
