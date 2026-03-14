using AppLista.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLista.ViewModels
{
    
    public class NotesViewModel : BaseViewModel
    {
        public ObservableCollection<Nota> Notas { get; set; } = new();
        List<Nota> todasNotas = new();

        public Command cargar_notascommand { get; }

        public NotesViewModel()
        {
            cargar_notascommand = new Command(async () => await cargar_notas());
        }

        async Task cargar_notas()
        {
            var notas = await App.Database.get_notas();

            todasNotas = notas.ToList();

            Notas.Clear();

            foreach (var nota in notas)
                Notas.Add(nota);
        }

        public void FiltrarNotas(string texto)
        {
            Notas.Clear();

            var filtradas = todasNotas
                .Where(n => n.titulo.ToLower().Contains(texto) ||
                            n.contenido.ToLower().Contains(texto));

            foreach (var nota in filtradas)
                Notas.Add(nota);
        }

        public async Task ExportarNotas()
        {
            var notas = await App.Database.get_notas();

            string json = System.Text.Json.JsonSerializer.Serialize(notas);

            string path = Path.Combine(FileSystem.AppDataDirectory, "notas.json");

            File.WriteAllText(path, json);

            await Application.Current.MainPage.DisplayAlert(
                "Exportado",
                "Notas guardadas en: " + path,
                "OK");
        }
    }
}
