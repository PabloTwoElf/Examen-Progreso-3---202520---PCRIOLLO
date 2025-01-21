using Examen_Progreso_3___202520___PCRIOLLO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Progreso_3___202520___PCRIOLLO.ViewModel
{
    public class buscarPeliculaCriolloViewModel : BindableObject
    {
        private readonly PeliculaBuscarServices _peliculaBuscarServices;

        private string _tituloPelicula;
        public string _resultado;
        public string TituloPelicula
        {
            get => _tituloPelicula;
            set
            {
                _tituloPelicula = value;
                OnPropertyChanged();
            }
        }

        public string Resultado
        {
            get => _resultado;
            set
            {
                _resultado = value;
                OnPropertyChanged();
            }
        }

        public Observable


    }
}
