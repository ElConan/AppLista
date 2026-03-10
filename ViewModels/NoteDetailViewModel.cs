using AppLista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace AppLista.ViewModels
{
    [QueryProperty(nameof(NoteId), "noteId")]
    public class NoteDetailViewModel : BaseViewModel
    {
        int _id;
        string _titulo;
        string _contenido;
        int noteId;

        public int NoteId
        {
            get => noteId;
            set
            {
                noteId = value;
                LoadNote(value);
            }
        }

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

            Nota nota = new Nota
            {
                id = id,
                titulo = titulo,
                contenido = contenido,
                fecha_act = DateTime.Now
            };

            await App.Database.guardar_notas(nota);

            await Shell.Current.GoToAsync("..");
        }

        async Task EliminarNota()
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Eliminar",
                "¿Deseas eliminar esta nota?",
                "Sí",
                "No");

            if (!confirm)
                return;

            Nota nota = new Nota
            {
                id = id
            };

            await App.Database.eliminar_notas(nota);

            await Shell.Current.GoToAsync("..");
        }
        async void LoadNote(int id)
        {
            var notes = await App.Database.get_notas();
            var note = notes.FirstOrDefault(n => n.id == id);

            if (note != null)
            {
                this.id = note.id;
                titulo = note.titulo;
                contenido = note.contenido;
            }
        }
    }
}
