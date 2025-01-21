using Examen_Progreso_3___202520___PCRIOLLO.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public ObservableCollection<string> GuardarPelicula { get; set; }

        public ICommand BuscarPeliculaCommand { get; }
        public ICommand LimpiarCommand { get; }



        public buscarPeliculaCriolloViewModel(PeliculaBuscarServices peliculaBuscarServices) {


            _peliculaBuscarServices = peliculaBuscarServices;
            GuardarPelicula = new ObservableCollection<string>();
            BuscarPeliculaCommand = new Command(async () => await BuscarPeliculaAsync());
            LimpiarCommand = new Command(() => Limpiar());

        }

        private async Task BuscarPeliculaAsync()
        {
            throw new NotImplementedException();
        }


        private void Limpiar()
        {
            throw new NotImplementedException();
        }

       
    }
}
