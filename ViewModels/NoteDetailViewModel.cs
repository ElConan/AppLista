using AppLista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppLista.ViewModels
{
    public class NoteDetailViewModel : BaseViewModel
    {
        int _id;
        string _titulo;
        string _contenido;

        public int id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        public string contenido
        {
            get => _contenido;
            set => SetProperty(ref _contenido, value);
        }

        public ICommand GuardarCommand { get; }
        public ICommand EliminarCommand { get; }

        public NoteDetailViewModel()
        {
            GuardarCommand = new Command(async () => await GuardarNota());
            EliminarCommand = new Command(async () => await EliminarNota());
        }

        async Task GuardarNota()
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El título no puede estar vacío",
                    "OK");
                return;
            }

            Nota nota = new()
            {
                id = _id,
                titulo = titulo,
                contenido = contenido,
                fecha_act = DateTime.Now
            };

            await App.Database.guardar_notas(nota);

            await Shell.Current.GoToAsync("..");
        }

        async Task EliminarNota()
        {
            if (id == 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "No se puede eliminar una nota que no ha sido guardada",
                    "OK");
                return;
            }
            Nota nota = new()
            {
                id = _id,
                titulo = titulo,
                contenido = contenido,
                fecha_act = DateTime.Now
            };
            bool confirmacion = await Application.Current.MainPage.DisplayAlert(
                "Confirmar eliminación",
                "¿Estás seguro de que deseas eliminar esta nota?",
                "Sí",
                "No");
            if (confirmacion)
            {
                await App.Database.eliminar_notas(nota);
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
