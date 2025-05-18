using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormDesbloquearCredencial : Form
    {

        private string pathCredenciales = @"..\..\..\Persistencia\DataBase\Tablas\credenciales.csv";
        private string legajoEncontrado = null;
        private string usuarioEncontrado = null;

        public FormDesbloquearCredencial()
        {
            InitializeComponent();
            this.Load += FormDesbloquearCredencial_Load;
        }
        private void FormDesbloquearCredencial_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            txtNuevaContraseñaDC.Enabled = false;
            btnDC.Enabled = false;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDC_Click(object sender, EventArgs e)
        {
            if (legajoEncontrado == null && usuarioEncontrado == null)
                return;

            string nuevaClave = txtNuevaContraseñaDC.Text.Trim();
            if (string.IsNullOrEmpty(nuevaClave))
                return;

            var lineas = System.IO.File.ReadAllLines(pathCredenciales);
            for (int i = 1; i < lineas.Length; i++)
            {
                var partes = lineas[i].Split(';');
                if ((legajoEncontrado != null && partes[0] == legajoEncontrado) ||
                    (usuarioEncontrado != null && partes[1] == usuarioEncontrado))
                {
                    // Actualiza la contraseña y deja fechaUltimoLogin vacía
                    partes[2] = nuevaClave;
                    partes[4] = "";
                    lineas[i] = string.Join(";", partes);
                    break;
                }
            }
            System.IO.File.WriteAllLines(pathCredenciales, lineas);

            MessageBox.Show("Contraseña actualizada correctamente. El usuario deberá cambiarla en su próximo ingreso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpia y deshabilita controles
            txtLegajoDC.Clear();
            txtUsuarioDC.Clear();
            txtNuevaContraseñaDC.Clear();
            txtNuevaContraseñaDC.Enabled = false;
            btnDC.Enabled = false;
            label2.Visible = false;
            label3.Visible = false;
            legajoEncontrado = null;
            usuarioEncontrado = null;
        }

        private void btnBuscarDC_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajoDC.Text.Trim();
            string usuario = txtUsuarioDC.Text.Trim();
            bool encontrado = false;

            // Oculta los labels y deshabilita controles por defecto
            label2.Visible = false;
            label3.Visible = false;
            txtNuevaContraseñaDC.Enabled = false;
            btnDC.Enabled = false;
            legajoEncontrado = null;
            usuarioEncontrado = null;

            if (string.IsNullOrEmpty(legajo) && string.IsNullOrEmpty(usuario))
                return;

            var lineas = System.IO.File.ReadAllLines(pathCredenciales);
            for (int i = 1; i < lineas.Length; i++) // Empieza en 1 para saltar encabezado
            {
                var partes = lineas[i].Split(';');
                if ((legajo != "" && partes[0] == legajo) || (usuario != "" && partes[1] == usuario))
                {
                    legajoEncontrado = partes[0];
                    usuarioEncontrado = partes[1];
                    label2.Text = $"Legajo {legajoEncontrado}";
                    label3.Text = $"Usuario {usuarioEncontrado}";
                    label2.Visible = true;
                    label3.Visible = true;
                    txtNuevaContraseñaDC.Enabled = true;
                    btnDC.Enabled = true;
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                label2.Text = "USUARIO Y/O LEGAJO NO ENCONTRADO";
                label2.Visible = true;
                label3.Visible = false;
                txtNuevaContraseñaDC.Enabled = false;
                btnDC.Enabled = false;
            }

        }

        private void btnSalirDC_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
