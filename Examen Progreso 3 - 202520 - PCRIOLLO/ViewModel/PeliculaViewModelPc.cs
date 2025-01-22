using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Examen_Progreso_3___202520___PCRIOLLO.Models;
using Examen_Progreso_3___202520___PCRIOLLO.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Examen_Progreso_3___202520___PCRIOLLO.ViewModel
{
    public partial class PeliculaViewModelPc : ObservableObject
    {
        private readonly PeliculaServicesPC _peliculaServicesPC;

        [ObservableProperty]
        private string nombrePelicula;

        [ObservableProperty]
        private string respuesta;

        public PeliculaViewModelPc(PeliculaServicesPC peliculaServicesPC)
        {
            _peliculaServicesPC = peliculaServicesPC;
        }

        [RelayCommand]
        public async Task BuscarPeliculaAsync()
        {
            try
            {
                using var httpClient = new HttpClient();
                string encodedNombrePelicula = Uri.EscapeDataString(NombrePelicula);
                string url = $"https://www.freetestapi.com/api/v1/movies?search={encodedNombrePelicula}";

                var response = await httpClient.GetFromJsonAsync<List<VistaApi>>(url);

                if (response != null && response.Count > 0)
                {
                    var pelicula = response[0];
                    var genero = pelicula.Genero != null && pelicula.Genero.Count > 0 ? string.Join(", ", pelicula.Genero) : "Estado ... Desconocido";
                    var actores = pelicula.Actores != null && pelicula.Actores.Count > 0 ? pelicula.Actores[0] : "Estado .... Desconocido";

                    Respuesta = $"Titulo: {pelicula.Titulo} \n" +
                                $"Genero: {genero} \n" +
                                $"Actores: {actores} \n" +
                                $"Reconocimientos: {pelicula.Reconocimientos} \n" +
                                $"Sitio Web: {pelicula.Website} \n Pablo Criollo Escobar";

                    var newPelicula = new peliculaPC
                    {
                        TituloPelicula = pelicula.Titulo,
                        GeneroPelicula = genero,
                        Actores = actores,
                        Premios = pelicula.Reconocimientos,
                        SitioWeb = pelicula.Website
                    };

                    _peliculaServicesPC.AddPelicula(newPelicula);
                }
                else
                {
                    Respuesta = "No se encontraron resultados para esa película.";
                }
            }
            catch (Exception ex)
            {
                Respuesta = $"Error al buscar la película: {ex.Message}";
            }
        }

        [RelayCommand]
        public void Limpiar()
        {
            NombrePelicula = string.Empty;
            Respuesta = string.Empty;
        }

        public class VistaApi
        {
            public string Titulo { get; set; }
            public List<string> Genero { get; set; }
            public List<string> Actores { get; set; }
            public string Reconocimientos { get; set; }
            public string Website { get; set; }
        }
    }
}
