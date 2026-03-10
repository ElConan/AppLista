using AppLista.Services;

namespace AppLista
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        static DBnota database;

        public static DBnota Database
        {
            get
            {
                if (database == null)
                {
                    string path_db = Path.Combine(FileSystem.AppDataDirectory, "notas.db");
                    database = new DBnota(path_db);
                }

                return database;
            }
        }
    }
}
