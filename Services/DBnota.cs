using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLista.Models;
using SQLite;

namespace AppLista.Services
{
    public class DBnota
    {
        SQLiteAsyncConnection database;

        public DBnota(string path_db)
        {
            database = new SQLiteAsyncConnection(path_db);
            database.CreateTableAsync<Nota>().Wait();
        }

        public Task<List<Nota>> get_notas() 
        {
            return database.Table<Nota>()
                .OrderByDescending(n => n.fijado)
                .ThenByDescending(n => n.fecha_act)
                .ToListAsync();
        }

        public Task<int> guardar_notas(Nota nota)
        {
            if (nota.id != 0)
            {
                return database.UpdateAsync(nota);
            }
            else
            {
                return database.InsertAsync(nota);
            }
        }

        public Task<int> eliminar_notas(Nota nota)
        {
            return database.DeleteAsync(nota);
        }
    }
}
