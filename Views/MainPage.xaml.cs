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
    }

}
