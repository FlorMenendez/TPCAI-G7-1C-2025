using Datos;
using Negocio;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            LoginNegocio loginNegocio = new LoginNegocio();

            try
            {
                if (loginNegocio.EstaBloqueado(usuario))
                {
                    lblMensaje.Text = "El usuario está bloqueado por exceso de intentos fallidos.";
                    lblMensaje.Visible = true;
                    return;
                }

                Credencial credencial = loginNegocio.login(usuario, password);

                if (credencial != null)
                {
                    // Si nunca inició sesión o pasaron más de 30 días
                    if (credencial.FechaUltimoLogin == DateTime.MinValue ||
                        (DateTime.Now - credencial.FechaUltimoLogin).TotalDays > 30)
                    {
                        MessageBox.Show("La contraseña ha expirado o nunca iniciaste sesión. Debes cambiarla.");
                        FormCambioClave cambioClave = new FormCambioClave(credencial);
                        cambioClave.ShowDialog();
                        return;
                    }

                    Perfil perfil = loginNegocio.ObtenerPerfilPorLegajo(credencial.Legajo);

                    if (perfil != null)
                    {
                        if (perfil.Nombre == "Supervisor")
                        {
                            FormSupervisor formSupervisor = new FormSupervisor();
                            formSupervisor.Show();
                            this.Hide();
                        }

                        if (perfil.Nombre == "Administrador")
                        {
                            FormAdministrador formAdministrador = new FormAdministrador();
                            formAdministrador.Show();
                            this.Hide();
                        }

                        if (perfil.Nombre == "Operador")
                        {
                            FormOperador formOperador = new FormOperador();
                            formOperador.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Bienvenido {credencial.NombreUsuario}. No se pudo identificar tu perfil.");
                    }

                }
                else
                {
                    lblMensaje.Text = "Usuario o contraseña incorrectos.";
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar iniciar sesión: " + ex.Message);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // No hace falta poner nada acá por ahora
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load_1(object sender, EventArgs e)
        {

        }

        private void lblMensaje_Click(object sender, EventArgs e)
        {

        }
    }
}