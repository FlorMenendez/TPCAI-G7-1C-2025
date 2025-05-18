using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TemplateTPCorto
{
    public partial class FormCambioClave : Form
    {
        private Credencial credencial;
        private string path = @"..\..\..\Persistencia\DataBase\Tablas\credenciales.csv";

        public FormCambioClave(Credencial credencial)
        {
            InitializeComponent();
            this.credencial = credencial;
        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            string nuevaClave = txtNuevaClave.Text;

            if (nuevaClave.Length < 8)
            {
                MessageBox.Show("La nueva contraseña debe tener al menos 8 caracteres.");
                return;
            }

            if (nuevaClave == credencial.Contrasena)
            {
                MessageBox.Show("La nueva contraseña debe ser distinta a la anterior.");
                return;
            }

            // Actualizar la contraseña en el archivo CSV
            string[] lineas = File.ReadAllLines(path);

            for (int i = 1; i < lineas.Length; i++) // Saltamos encabezado
            {
                string[] campos = lineas[i].Split(';');
                if (campos.Length >= 5 && campos[1] == credencial.NombreUsuario)
                {
                    campos[2] = nuevaClave;
                    campos[4] = DateTime.Now.ToString("d/M/yyyy"); // actualiza FechaUltimoLogin
                    lineas[i] = string.Join(";", campos);
                    break;
                }
            }

            File.WriteAllLines(path, lineas);

            MessageBox.Show("Contraseña actualizada correctamente.");
            this.Close();
        }

        private void FormCambioClave_Load(object sender, EventArgs e)
        {
            // Por ahora no hace nada
        }
    }
}
