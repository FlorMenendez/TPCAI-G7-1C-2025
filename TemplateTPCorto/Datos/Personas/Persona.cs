using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Persona
    {
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Persona() { }

        public Persona(string registro)
        {
            // Formato: legajo;nombre;apellido;dni;fecha_ingreso
            string[] campos = registro.Split(';');
            if (campos.Length >= 5)
            {
                Legajo = campos[0];
                Nombre = campos[1];
                Apellido = campos[2];
                Dni = int.Parse(campos[3]);
                FechaIngreso = DateTime.ParseExact(campos[4], "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        public override string ToString()
        {
            return $"{Legajo};{Nombre};{Apellido};{Dni};{FechaIngreso.ToString("d/M/yyyy")}";
        }
        public string NombreYApellido
        {
            get { return $"{Nombre} {Apellido}"; }
        }

    }
}
