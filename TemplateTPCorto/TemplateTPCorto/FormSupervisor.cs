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
    public partial class FormSupervisor : Form
    {
        public FormSupervisor()
        {
            InitializeComponent();
        }

        private void FormSupervisor_Load(object sender, EventArgs e)
        {

        }

        private void btnModificarPersona_Click(object sender, EventArgs e)
        {
            FormModificarPersona form = new FormModificarPersona();
            form.ShowDialog();
        }

        private void btnDesbloquearCredencial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Acá iría la funcionalidad para desbloquear credenciales.");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }

    }
}
