using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Credencial
    {
        public string Legajo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaUltimoLogin { get; set; }

        public Credencial() { }

        public Credencial(string registro)
        {
            string[] datos = registro.Split(';');

            if (datos.Length >= 5)
            {
                Legajo = datos[0];
                NombreUsuario = datos[1];
                Contrasena = datos[2];
                FechaAlta = DateTime.ParseExact(datos[3], "d/M/yyyy", CultureInfo.InvariantCulture);
                if (string.IsNullOrWhiteSpace(datos[4]))
                {
                    FechaUltimoLogin = DateTime.MinValue;
                }
                else
                {
                    FechaUltimoLogin = DateTime.ParseExact(datos[4], "d/M/yyyy", CultureInfo.InvariantCulture);
                }
            }
        }
    }
}
