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

        public Command cargar_notascommand { get; }

        public NotesViewModel()
        {
            cargar_notascommand = new Command(async () => await cargar_notas());
        }

        async Task cargar_notas()
        {
            var notas = await App.Database.get_notas();
            Notas.Clear();

            foreach (var nota in notas)
            {
                Notas.Add(nota);
            }
        }
    }
}
