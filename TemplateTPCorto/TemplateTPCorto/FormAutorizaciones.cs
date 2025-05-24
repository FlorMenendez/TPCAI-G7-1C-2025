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
    public partial class FormAutorizaciones : Form
    {
        public FormAutorizaciones()
        {
            InitializeComponent();
        }

        private void Persona_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Cierra este formulario y vuelve al menú del Administrador
            this.Close();
        }

        private void FormAutorizaciones_Load(object sender, EventArgs e)
        {
            // —— OPERACIONES DE PERSONA ——
            string pathPers = @"..\..\..\Persistencia\DataBase\Tablas\operacion_cambio_persona.csv";
            if (File.Exists(pathPers))
            {
                var listaPers = File.ReadAllLines(pathPers)
                                     .Skip(1) // saltar encabezado
                                     .Select(linea => linea.Split(';'))
                                     .Select(cam => new
                                     {
                                         IdOperacion = cam[0],
                                         Legajo = cam[1],
                                         Nombre = cam[2],
                                         Apellido = cam[3],
                                         Dni = cam[4],
                                         FechaIngreso = cam[5]
                                     })
                                     .ToList();
                dgvPersona.DataSource = listaPers;
            }

            // —— OPERACIONES DE CREDENCIAL ——
            string pathCred = @"..\..\..\Persistencia\DataBase\Tablas\operacion_cambio_credencial.csv";
            if (File.Exists(pathCred))
            {
                var listaCred = File.ReadAllLines(pathCred)
                    .Skip(1)                                   // salto encabezado
                    .Where(linea => !string.IsNullOrWhiteSpace(linea))
                    .Select(linea =>
                    {
                        var cam = linea.Split(';');
                        return new
                        {
                            IdOperacion = cam.Length > 0 ? cam[0] : "",
                            Legajo = cam.Length > 1 ? cam[1] : "",
                            NombreUsuario = cam.Length > 2 ? cam[2] : "",
                            Contrasena = cam.Length > 3 ? cam[3] : "",
                            IdPerfil = cam.Length > 4 ? cam[4] : "",
                            FechaAlta = cam.Length > 5 ? cam[5] : "",
                            FechaUltimoLogin = cam.Length > 6 ? cam[6] : ""
                        };
                    })
                    .ToList();

                dgvCredencial.DataSource = listaCred;
            }

        }

        private void btnAprobarPersona_Click(object sender, EventArgs e)
        {
            if (dgvPersona.CurrentRow == null) return;

            // 1) Obtengo datos de la operación pendiente
            string idOp = dgvPersona.CurrentRow.Cells["IdOperacion"].Value.ToString();
            string legajo = dgvPersona.CurrentRow.Cells["Legajo"].Value.ToString();
            string nombre = dgvPersona.CurrentRow.Cells["Nombre"].Value.ToString();
            string apellido = dgvPersona.CurrentRow.Cells["Apellido"].Value.ToString();
            string dni = dgvPersona.CurrentRow.Cells["Dni"].Value.ToString();
            string fechaIng = dgvPersona.CurrentRow.Cells["FechaIngreso"].Value.ToString();

            // 2) Aplico el cambio en persona.csv
            string pathPersCsv = @"..\..\..\Persistencia\DataBase\Tablas\persona.csv";
            var persLines = File.ReadAllLines(pathPersCsv).ToList();
            for (int i = 1; i < persLines.Count; i++)
            {
                var c = persLines[i].Split(';');
                if (c[0] == legajo)
                {
                    c[1] = nombre;
                    c[2] = apellido;
                    c[3] = dni;
                    c[4] = fechaIng;
                    persLines[i] = string.Join(";", c);
                    break;
                }
            }
            File.WriteAllLines(pathPersCsv, persLines);

            // 3) Registrar autorización
            string pathAuth = @"..\..\..\Persistencia\DataBase\Tablas\autorizacion.csv";
            var authLines = File.Exists(pathAuth)
                ? File.ReadAllLines(pathAuth).ToList()
                : new List<string> { "idOperacion;tipoOperacion;estado;legajoSolicitante;fechaSolicitud;legajoAutorizador;fechaAutorizacion" };
            int newAuthId = authLines.Count;
            string ahora = DateTime.Now.ToString("d/M/yyyy");
            string adminLegajo = "2034"; // <- ajustá con el legajo real del Admin actual
            authLines.Add($"{newAuthId};Persona;APROBADO;{legajo};{ahora};{adminLegajo};{ahora}");
            File.WriteAllLines(pathAuth, authLines);

            // 4) Quitar de pendientes
            string pathOpPers = @"..\..\..\Persistencia\DataBase\Tablas\operacion_cambio_persona.csv";
            var opsPers = File.ReadAllLines(pathOpPers)
                              .Where(l => !l.StartsWith(idOp + ";"))
                              .ToArray();
            File.WriteAllLines(pathOpPers, opsPers);

            // 5) Refrescar tabla
            FormAutorizaciones_Load(null, null);
        }

        private void btnRechazarPersona_Click(object sender, EventArgs e)
        {
            if (dgvPersona.CurrentRow == null) return;

            string idOp = dgvPersona.CurrentRow.Cells["IdOperacion"].Value.ToString();
            string legajo = dgvPersona.CurrentRow.Cells["Legajo"].Value.ToString();

            // Registrar rechazo
            string pathAuth = @"..\..\..\Persistencia\DataBase\Tablas\autorizacion.csv";
            var authLines = File.Exists(pathAuth)
                ? File.ReadAllLines(pathAuth).ToList()
                : new List<string> { "idOperacion;tipoOperacion;estado;legajoSolicitante;fechaSolicitud;legajoAutorizador;fechaAutorizacion" };
            int newAuthId = authLines.Count;
            string ahora = DateTime.Now.ToString("d/M/yyyy");
            string adminLegajo = "2034";
            authLines.Add($"{newAuthId};Persona;RECHAZADO;{legajo};{ahora};{adminLegajo};{ahora}");
            File.WriteAllLines(pathAuth, authLines);

            // Quitar de pendientes
            string pathOpPers = @"..\..\..\Persistencia\DataBase\Tablas\operacion_cambio_persona.csv";
            var opsPers = File.ReadAllLines(pathOpPers)
                              .Where(l => !l.StartsWith(idOp + ";"))
                              .ToArray();
            File.WriteAllLines(pathOpPers, opsPers);

            FormAutorizaciones_Load(null, null);
        }

        private void btnAprobarCred_Click(object sender, EventArgs e)
        {
            if (dgvCredencial.CurrentRow == null) return;

            // 1) Datos de la operación
            var cells = dgvCredencial.CurrentRow.Cells;
            string idOp = cells["IdOperacion"].Value.ToString();
            string legajo = cells["Legajo"].Value.ToString();
            string usuario = cells["NombreUsuario"].Value.ToString();
            string nuevaClave = cells["Contrasena"].Value.ToString();

            // 2) Actualizar credenciales.csv
            string pathCred = @"..\..\..\Persistencia\DataBase\Tablas\credenciales.csv";
            var credLines = File.ReadAllLines(pathCred).ToList();
            for (int i = 1; i < credLines.Count; i++)
            {
                var c = credLines[i].Split(';');
                if (c[0] == legajo)
                {
                    c[2] = nuevaClave;
                    c[4] = "";  // forzar cambio al login
                    credLines[i] = string.Join(";", c);
                    break;
                }
            }
            File.WriteAllLines(pathCred, credLines);

            // 3) Autorizar
            string pathAuth = @"..\..\..\Persistencia\DataBase\Tablas\autorizacion.csv";
            var authLines = File.Exists(pathAuth)
                ? File.ReadAllLines(pathAuth).ToList()
                : new List<string> { "idOperacion;tipoOperacion;estado;legajoSolicitante;fechaSolicitud;legajoAutorizador;fechaAutorizacion" };
            int newAuthId = authLines.Count;
            string ahora = DateTime.Now.ToString("d/M/yyyy");
            string adminLegajo = "2034";
            authLines.Add($"{newAuthId};Credencial;APROBADO;{legajo};{ahora};{adminLegajo};{ahora}");
            File.WriteAllLines(pathAuth, authLines);

            // 4) Quitar de pendientes
            string pathOpCred = @"..\..\..\Persistencia\DataBase\Tablas\operacion_cambio_credencial.csv";
            var opsCred = File.ReadAllLines(pathOpCred)
                              .Where(l => !l.StartsWith(idOp + ";"))
                              .ToArray();
            File.WriteAllLines(pathOpCred, opsCred);

            FormAutorizaciones_Load(null, null);
        }

        private void btnRechazarCred_Click(object sender, EventArgs e)
        {
            if (dgvCredencial.CurrentRow == null) return;

            string idOp = dgvCredencial.CurrentRow.Cells["IdOperacion"].Value.ToString();
            string legajo = dgvCredencial.CurrentRow.Cells["Legajo"].Value.ToString();

            // Registrar rechazo
            string pathAuth = @"..\..\..\Persistencia\DataBase\Tablas\autorizacion.csv";
            var authLines = File.Exists(pathAuth)
                ? File.ReadAllLines(pathAuth).ToList()
                : new List<string> { "idOperacion;tipoOperacion;estado;legajoSolicitante;fechaSolicitud;legajoAutorizador;fechaAutorizacion" };
            int newAuthId = authLines.Count;
            string ahora = DateTime.Now.ToString("d/M/yyyy");
            string adminLegajo = "2034";
            authLines.Add($"{newAuthId};Credencial;RECHAZADO;{legajo};{ahora};{adminLegajo};{ahora}");
            File.WriteAllLines(pathAuth, authLines);

            // Quitar de pendientes
            string pathOpCred = @"..\..\..\Persistencia\DataBase\Tablas\operacion_cambio_credencial.csv";
            var opsCred = File.ReadAllLines(pathOpCred)
                              .Where(l => !l.StartsWith(idOp + ";"))
                              .ToArray();
            File.WriteAllLines(pathOpCred, opsCred);

            FormAutorizaciones_Load(null, null);
        }
    }
}