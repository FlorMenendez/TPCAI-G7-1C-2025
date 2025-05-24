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
            // 1) Validaciones iniciales
            if (legajoEncontrado == null && usuarioEncontrado == null)
                return;

            string nuevaClave = txtNuevaContraseñaDC.Text.Trim();
            if (string.IsNullOrEmpty(nuevaClave) || nuevaClave.Length < 8)
            {
                MessageBox.Show("La nueva contraseña debe tener al menos 8 caracteres.");
                return;
            }

            // 2) Leer datos originales de la credencial
            //    para obtener legajo, fechaAlta e idPerfil
            string[] credLineas = File.ReadAllLines(pathCredenciales);
            string fechaAlta = "";
            string idPerfil = "";
            foreach (var lin in credLineas.Skip(1))
            {
                var c = lin.Split(';');
                if (c.Length >= 6 && c[1] == usuarioEncontrado)
                {
                    fechaAlta = c[3];
                    idPerfil = c[5];  // si tu CSV tiene el idPerfil en la columna 6
                    break;
                }
            }

            // 3) Registrar la operación pendiente en operacion_cambio_credencial.csv
            string pathOpCred = @"..\..\..\Persistencia\DataBase\Tablas\operacion_cambio_credencial.csv";
            if (!File.Exists(pathOpCred))
            {
                // crear archivo con encabezado + primera operación (ID=1)
                File.WriteAllLines(pathOpCred, new[]
                {
            "idOperacion;legajo;nombreUsuario;contrasena;idPerfil;fechaAlta;fechaUltimoLogin",
            $"1;{legajoEncontrado};{usuarioEncontrado};{nuevaClave};{idPerfil};{fechaAlta};"
        });
            }
            else
            {
                // Calculo el nuevo ID
                var existentes = File.ReadAllLines(pathOpCred);
                int nuevoId = existentes.Length;

                // Preparo la línea
                string opLine = $"{nuevoId};{legajoEncontrado};{usuarioEncontrado};{nuevaClave};{idPerfil};{fechaAlta};";

                // Añado la línea precedida de un salto de línea para que no se pegue al encabezado
                File.AppendAllText(pathOpCred, Environment.NewLine + opLine);
            }

            // 4) Sacar al usuario de usuario_bloqueado.csv
            string pathBloq = @"..\..\..\Persistencia\DataBase\Tablas\usuario_bloqueado.csv";
            if (File.Exists(pathBloq))
            {
                var sinEste = File.ReadAllLines(pathBloq)
                                 .Where(u => !u.Trim().Equals(usuarioEncontrado, StringComparison.OrdinalIgnoreCase))
                                 .ToArray();
                File.WriteAllLines(pathBloq, sinEste);
            }

            // 5) Mensaje y limpieza de controles
            MessageBox.Show(
               "El desbloqueo ha quedado pendiente de aprobación por el Administrador.",
               "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            this.Close();
        }

        private void FormDesbloquearCredencial_Load_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
