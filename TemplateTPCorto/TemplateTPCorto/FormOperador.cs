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
    public partial class FormOperador : Form
    {
        public FormOperador()
        {
            InitializeComponent();
        }

        private void btnCargarVenta_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            FormVentas formVentas = new FormVentas();
            formVentas.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close(); 
        }

        private void FormOperador_Load(object sender, EventArgs e)
        {

        }
    }
}
