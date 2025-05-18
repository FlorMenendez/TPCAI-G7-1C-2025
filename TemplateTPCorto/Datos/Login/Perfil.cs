using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Perfil
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Perfil(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
