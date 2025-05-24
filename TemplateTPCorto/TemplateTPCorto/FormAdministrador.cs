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
    public partial class FormAdministrador : Form
    {
        public FormAdministrador()
        {
            InitializeComponent();
        }

        private void btnAutorizaciones_Click(object sender, EventArgs e)
        {
            FormAutorizaciones form = new FormAutorizaciones();
            form.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            this.Close();
        }

        private void FormAdministrador_Load(object sender, EventArgs e)
        {

        }
    }
}
