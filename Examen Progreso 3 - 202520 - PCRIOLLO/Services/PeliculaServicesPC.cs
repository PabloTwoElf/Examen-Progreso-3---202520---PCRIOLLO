using Examen_Progreso_3___202520___PCRIOLLO.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Progreso_3___202520___PCRIOLLO.Services
{
    public class PeliculaServicesPC
    {

        private readonly SQLiteConnection _database;

        public PeliculaServicesPC()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "criolloPabloPeliculas.db");
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<peliculaPC>();
        }

        public List<peliculaPC> GetMovies()
        {
            return _database.Table<peliculaPC >().ToList();
        }

        public void AddMovie(peliculaPC pelicula)
        {
            _database.Insert(pelicula);
        }



    }
}
