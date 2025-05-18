using Datos;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Persistencia
{
    public class UsuarioPersistencia
    {
        public Credencial login(string username)
        {
            string path = @"..\..\..\Persistencia\DataBase\Tablas\credenciales.csv";

            if (!File.Exists(path))
                return null;

            var lineas = File.ReadAllLines(path);

            for (int i = 1; i < lineas.Length; i++) // Saltamos encabezado
            {
                string linea = lineas[i];

                if (string.IsNullOrWhiteSpace(linea))
                    continue;

                string[] campos = linea.Split(';');

                if (campos.Length < 5)
                    continue;

                if (campos[1].Trim().Equals(username.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return new Credencial(linea);
                }
            }

            return null;
        }
    }
}
