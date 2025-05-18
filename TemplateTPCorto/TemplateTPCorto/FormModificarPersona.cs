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
using Datos;

namespace TemplateTPCorto
{
    public partial class FormModificarPersona : Form
    {
        private bool cargandoCombo = false;
        private List<Persona> personas = new List<Persona>();

        public FormModificarPersona()
        {
            InitializeComponent();
        }

        private void FormModificarPersona_Load(object sender, EventArgs e)
        {
            cargandoCombo = true;

            // Esto hace que el selector de fecha se vea "en blanco" al inicio
            dtpFechaIngreso.Format = DateTimePickerFormat.Custom;
            dtpFechaIngreso.CustomFormat = " ";

            string path = @"..\..\..\Persistencia\DataBase\Tablas\persona.csv";

            if (File.Exists(path))
            {
                string[] lineas = File.ReadAllLines(path);

                for (int i = 1; i < lineas.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(lineas[i]))
                    {
                        Persona p = new Persona(lineas[i]);
                        personas.Add(p);
                    }
                }

                cmbPersonas.DisplayMember = "NombreYApellido";
                cmbPersonas.DataSource = personas;
                cmbPersonas.SelectedIndex = -1;
            }

            cargandoCombo = false;
        }


        private void cmbPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombo || cmbPersonas.SelectedIndex == -1)
            {
                txtLegajo.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtDNI.Text = "";

                // Ocultar fecha simulando "vacío"
                dtpFechaIngreso.Format = DateTimePickerFormat.Custom;
                dtpFechaIngreso.CustomFormat = " ";

                return;
            }

            Persona seleccionada = (Persona)cmbPersonas.SelectedItem;

            txtLegajo.Text = seleccionada.Legajo;
            txtNombre.Text = seleccionada.Nombre;
            txtApellido.Text = seleccionada.Apellido;
            txtDNI.Text = seleccionada.Dni.ToString();

            // Mostrar la fecha en formato corto
            dtpFechaIngreso.Format = DateTimePickerFormat.Short;
            dtpFechaIngreso.Value = seleccionada.FechaIngreso;
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbPersonas.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná una persona primero.");
                return;
            }

            Persona seleccionada = (Persona)cmbPersonas.SelectedItem;

            // Actualizamos los valores
            seleccionada.Nombre = txtNombre.Text;
            seleccionada.Apellido = txtApellido.Text;

            int dni;
            if (!int.TryParse(txtDNI.Text, out dni))
            {
                MessageBox.Show("El DNI debe ser un número válido.");
                return;
            }
            seleccionada.Dni = dni;

            seleccionada.FechaIngreso = dtpFechaIngreso.Value;

            // Sobrescribimos el archivo
            string path = @"..\..\..\Persistencia\DataBase\Tablas\persona.csv";

            if (File.Exists(path))
            {
                List<string> nuevasLineas = new List<string>();
                nuevasLineas.Add("legajo;nombre;apellido;dni;fecha_ingreso"); // encabezado

                foreach (var persona in personas)
                {
                    nuevasLineas.Add(persona.ToString());
                }

                File.WriteAllLines(path, nuevasLineas);
                MessageBox.Show("Datos actualizados correctamente.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

