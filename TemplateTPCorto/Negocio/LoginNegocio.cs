using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Negocio
{
    public class LoginNegocio
    {
        private string pathIntentos = @"..\..\..\Persistencia\DataBase\Tablas\login_intentos.csv";
        private string pathBloqueados = @"..\..\..\Persistencia\DataBase\Tablas\usuario_bloqueado.csv";

        public bool EstaBloqueado(string usuario)
        {
            if (!File.Exists(pathBloqueados))
                return false;

            string[] bloqueados = File.ReadAllLines(pathBloqueados);
            foreach (string linea in bloqueados)
            {
                if (linea.Trim().Equals(usuario.Trim(), System.StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public Credencial login(string usuario, string contraseña)
        {
            if (EstaBloqueado(usuario))
                throw new System.Exception("El usuario está bloqueado por exceso de intentos fallidos.");

            UsuarioPersistencia persistencia = new UsuarioPersistencia();
            Credencial credencial = persistencia.login(usuario);

            if (credencial != null && credencial.Contrasena == contraseña)
            {
                ReiniciarIntentos(usuario);
                return credencial;
            }

            RegistrarIntentoFallido(usuario);
            return null;
        }

        private void RegistrarIntentoFallido(string usuario)
        {
            Dictionary<string, int> intentos = new Dictionary<string, int>();

            if (File.Exists(pathIntentos))
            {
                string[] lineas = File.ReadAllLines(pathIntentos);
                foreach (string linea in lineas)
                {
                    string[] partes = linea.Split(';');
                    if (partes.Length == 2)
                    {
                        int valor;
                        if (int.TryParse(partes[1], out valor))
                        {
                            intentos[partes[0]] = valor;
                        }
                    }
                }
            }

            if (intentos.ContainsKey(usuario))
                intentos[usuario]++;
            else
                intentos[usuario] = 1;

            if (intentos[usuario] == 3)
            {
                // Bloquear al usuario
                using (StreamWriter sw = File.AppendText(pathBloqueados))
                {
                    sw.WriteLine(usuario);
                }
            }

            // Guardar nuevamente los intentos
            using (StreamWriter sw = new StreamWriter(pathIntentos, false))
            {
                foreach (var kvp in intentos)
                {
                    sw.WriteLine($"{kvp.Key};{kvp.Value}");
                }
            }
        }

        private void ReiniciarIntentos(string usuario)
        {
            Dictionary<string, int> intentos = new Dictionary<string, int>();

            if (File.Exists(pathIntentos))
            {
                string[] lineas = File.ReadAllLines(pathIntentos);
                foreach (string linea in lineas)
                {
                    string[] partes = linea.Split(';');
                    if (partes.Length == 2 && partes[0] != usuario)
                    {
                        intentos[partes[0]] = int.Parse(partes[1]);
                    }
                }
            }
            // Guardar el archivo sin el usuario
            using (StreamWriter sw = new StreamWriter(pathIntentos, false))
            {
                foreach (var kvp in intentos)
                {
                    sw.WriteLine($"{kvp.Key};{kvp.Value}");
                }
            }


        }
        public Perfil ObtenerPerfilPorLegajo(string legajo)
        {
            string pathUsuarioPerfil = @"..\..\..\Persistencia\DataBase\Tablas\usuario_perfil.csv";
            string pathPerfiles = @"..\..\..\Persistencia\DataBase\Tablas\perfil.csv";

            if (!File.Exists(pathUsuarioPerfil) || !File.Exists(pathPerfiles))
                return null;

            string idPerfil = null;

            // Paso 1: Buscar el idPerfil del legajo
            string[] lineasUsuarioPerfil = File.ReadAllLines(pathUsuarioPerfil);
            for (int i = 1; i < lineasUsuarioPerfil.Length; i++) // saltamos encabezado
            {
                var partes = lineasUsuarioPerfil[i].Split(';');
                if (partes.Length >= 2 && partes[0].Trim() == legajo)
                {
                    idPerfil = partes[1].Trim();
                    break;
                }
            }

            if (idPerfil == null)
                return null;

            // Paso 2: Buscar la descripción del perfil
            string[] lineasPerfiles = File.ReadAllLines(pathPerfiles);
            for (int i = 1; i < lineasPerfiles.Length; i++)
            {
                var partes = lineasPerfiles[i].Split(';');
                if (partes.Length >= 2 && partes[0].Trim() == idPerfil)
                {
                    return new Perfil(int.Parse(partes[0]), partes[1].Trim());
                }
            }

            return null;
        }
    }
}
