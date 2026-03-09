using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppLista.Models
{
    public class Nota
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string titulo { get; set; }

        public string contenido { get; set; }

        public DateTime fecha_creada { get; set; }

        public DateTime fecha_act { get; set; }

        public bool fijado { get; set; }
    }
}
