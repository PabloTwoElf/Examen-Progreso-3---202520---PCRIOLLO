using CommunityToolkit.Mvvm.ComponentModel;
using Examen_Progreso_3___202520___PCRIOLLO.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Progreso_3___202520___PCRIOLLO.ViewModel
{
    public partial class EnlistarViewModelPC : ObservableObject

    {

        private readonly PeliculaServicesPC   _peliculaServicesPC;

        [ObservableProperty]
        private ObservableCollection<string> peliculas;

        public EnlistarViewModelPC()
        {
            _peliculaServicesPC = new PeliculaServicesPC();
            CargarPelicula ();
        }

        private async void CargarPelicula()
        {
            var listaPeliculas = _peliculaServicesPC.GetPelicula();
            Peliculas = new ObservableCollection<string>(
                listaPeliculas.Select(m =>
                    $"Titulo: {m.TituloPelicula}\nGenero: {m.GeneroPelicula}\nMain Actor: {m.Actores}\nAwards: {m.Premios}\nWebsite: {m.SitioWeb}\n Pablo Criollo Escobar"
                )
            );
        }
    }
}
