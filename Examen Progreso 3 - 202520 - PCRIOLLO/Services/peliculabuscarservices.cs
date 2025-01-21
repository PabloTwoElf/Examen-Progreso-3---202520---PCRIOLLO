using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Examen_Progreso_3___202520___PCRIOLLO.Services
{
    public class PeliculaBuscarServices
    {
        private readonly HttpClient _httpClient;

        public PeliculaBuscarServices()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<PeliculaDatos>> BuscarPeliculaAsync(string tituloPelicula)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tituloPelicula))
                    throw new ArgumentException("El nombre de la película no puede estar vacío.");

                string apiUrl = $"https://freetestapi.com/api/v1/movies?search={tituloPelicula}&limit=1";
                var response = await _httpClient.GetFromJsonAsync<ApiResponse>(apiUrl);

                if (response?.Data != null && response.Data.Any())
                {
                    return response.Data;
                }

                return new List<PeliculaDatos>();
            }
            catch (Exception)
            {
                return new List<PeliculaDatos>();
            }
        }

        public class ApiResponse
        {
            public List<PeliculaDatos> Data { get; set; } = new();
        }

        public class PeliculaDatos
        {
            public string Name { get; set; }
            public List<string> Genero { get; set; }
            public List<string> ActorPrincipal { get; set; }
            public string Awards { get; set; }
            public string Website { get; set; }
        }
    }
}
