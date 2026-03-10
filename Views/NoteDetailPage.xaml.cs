using AppLista.ViewModels;

namespace AppLista.Views;

public partial class NoteDetailPage : ContentPage
{
	public NoteDetailPage()
	{
		InitializeComponent();

        BindingContext = new NoteDetailViewModel();
    }
}