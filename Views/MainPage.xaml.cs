using AppLista.Models;
using AppLista.ViewModels;

namespace AppLista.Views
{
    public partial class MainPage : ContentPage
    {
        NotesViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new NotesViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.cargar_notascommand.Execute(null);
        }

        async void OnAddNote(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NoteDetailPage");
        }

        async void OnNoteSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Nota selectedNote)
            {
                await Shell.Current.GoToAsync($"{nameof(NoteDetailPage)}?noteId={selectedNote.id}");

                ((CollectionView)sender).SelectedItem = null;

            }
        }

        async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = e.NewTextValue.ToLower();

            viewModel.FiltrarNotas(texto);
        }

        async void OnExport(object sender, EventArgs e)
        {
            await viewModel.ExportarNotas();
        }
    }

}
