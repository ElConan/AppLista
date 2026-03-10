namespace AppLista
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("NoteDetailPage", typeof(Views.NoteDetailPage));
        }
    }
}
