using Datos.Ventas;
using Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormVentas : Form
    {
        private List<Producto> productosOriginales = new List<Producto>();
        public FormVentas()
        {
            InitializeComponent();
            cmbCategorias.SelectedIndexChanged += cmbCategorias_SelectedIndexChanged;
            dgvCarrito.CellContentClick += dgvCarrito_CellContentClick;
            dgvCarrito.CellEndEdit += dgvCarrito_CellEndEdit;
            btnConfirmarVenta.Click += btnConfirmarVenta_Click;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormOperador formOperador = new FormOperador();
            formOperador.Show();
            this.Close();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarCategorias();

            lblSubtotal.Visible = false;
            lblTotal.Visible = false;
            lblDescuento.Visible = false;
        }

        private void CargarClientes()
        {
            ClientePersistencia clientePersistencia = new ClientePersistencia();
            List<Cliente> clientes = clientePersistencia.obtenerClientes();

            // Orden alfabético por Apellido + Nombre
            var clientesOrdenados = clientes
                .OrderBy(c => c.Apellido)
                .ThenBy(c => c.Nombre)
                .ToList();

            cmbClientes.DataSource = null;
            cmbClientes.Items.Clear();

            // No seteamos DisplayMember ni ValueMember → usa ToString()
            cmbClientes.Items.AddRange(clientesOrdenados.ToArray());
        }


        private void CargarCategorias()
        {
            var categorias = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(0, "-- Seleccioná una categoría --"),
                new KeyValuePair<int, string>(1, "Audio"),
                new KeyValuePair<int, string>(2, "Celulares"),
                new KeyValuePair<int, string>(3, "Electro Hogar"),
                new KeyValuePair<int, string>(4, "Informática"),
                new KeyValuePair<int, string>(5, "Smart TV")
            };

            cmbCategorias.DataSource = categorias;
            cmbCategorias.DisplayMember = "Value";
            cmbCategorias.ValueMember = "Key";
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategorias.SelectedValue is int categoriaId)
            {
                CargarProductosPorCategoria(categoriaId);
            }
        }

        private void CargarProductosPorCategoria(int idCategoria)
        {
            ProductoPersistencia productoPersistencia = new ProductoPersistencia();
            List<Producto> productos = productoPersistencia.obtenerProductosPorCategoria(idCategoria.ToString());

            // Filtrar productos con stock > 0
            var productosConStock = productos.Where(p => p.Stock > 0).ToList();

            lstProductos.DataSource = productosConStock;
            lstProductos.DisplayMember = "Nombre";
            lstProductos.ValueMember = "Id";
        }


        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCarrito.Rows.Count &&
    dgvCarrito.Columns[e.ColumnIndex].Name == "btnQuitar")
            {
                dgvCarrito.Rows.RemoveAt(e.RowIndex);
                ActualizarTotales();
            }

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (lstProductos.SelectedItem is Producto productoSeleccionado)
            {
                int precioUnitario = productoSeleccionado.Precio;
                int cantidad = 1;
                int subtotal = precioUnitario * cantidad;

                dgvCarrito.Rows.Add(
                    productoSeleccionado.Nombre,
                    precioUnitario,
                    cantidad,
                    subtotal,
                    "Quitar"
                );

                ActualizarTotales();

                btnConfirmarVenta.Enabled = true;
            }
            else
            {
                MessageBox.Show("Por favor, seleccioná un producto.");
            }

        }
        private void ActualizarTotales()
        {
            int subtotal = 0;

            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                if (fila.Cells["colSubtotal"].Value != null)
                {
                    subtotal += Convert.ToInt32(fila.Cells["colSubtotal"].Value);
                }
            }

            int descuento = 0;

            if (subtotal > 1000000)
            {
                descuento = (int)(subtotal * 0.15); // calculamos el 15% de descuento
            }

            int total = subtotal - descuento;

            lblSubtotal.Text = $"Subtotal: ${subtotal.ToString("N2")}";
            lblDescuento.Text = $"Descuento: ${descuento.ToString("N2")}";
            lblTotal.Text = $"Total: ${total.ToString("N2")}";

            bool hayProductos = dgvCarrito.Rows.Count > 0;

            lblSubtotal.Visible = hayProductos;
            lblDescuento.Visible = hayProductos && descuento > 0;
            lblTotal.Visible = hayProductos;

            btnConfirmarVenta.Enabled = hayProductos;
        }

        private void dgvCarrito_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCarrito.Columns[e.ColumnIndex].Name == "colCantidad" && e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvCarrito.Rows[e.RowIndex];

                int cantidad = 1;
                int precioUnitario = 0;

                try
                {
                    cantidad = Convert.ToInt32(fila.Cells["colCantidad"].Value);
                    precioUnitario = Convert.ToInt32(fila.Cells["colPrecioUnitario"].Value);
                }
                catch
                {
                    MessageBox.Show("La cantidad debe ser un número válido.");
                    cantidad = 1;
                    fila.Cells["colCantidad"].Value = 1;
                }

                int subtotal = precioUnitario * cantidad;
                fila.Cells["colSubtotal"].Value = subtotal;

                ActualizarTotales();
            }
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (!(cmbClientes.SelectedItem is Cliente clienteSeleccionado))
            {
                MessageBox.Show("Por favor, seleccioná un cliente.");
                return;
            }

            // Verificamos que haya filas antes de continuar
            if (dgvCarrito.Rows.Count == 0)
            {
                // Si el botón estaba deshabilitado antes (porque ya se hizo una venta), no muestro el mensaje
                if (!btnConfirmarVenta.Enabled)
                    return;

                MessageBox.Show("El carrito está vacío.");
                return;
            }

            Guid idCliente = clienteSeleccionado.Id;
            Guid idUsuario = new Guid("784c07f2-2b26-4973-9235-4064e94832b5");
            VentaPersistencia ventaPersistencia = new VentaPersistencia();
            string errores = "";

            for (int i = 0; i < dgvCarrito.Rows.Count; i++)
            {
                DataGridViewRow fila = dgvCarrito.Rows[i];

                if (i >= productosOriginales.Count)
                    continue;

                string nombreProducto = fila.Cells["colProducto"].Value?.ToString();
                Producto producto = lstProductos.Items
                    .Cast<Producto>()
                    .FirstOrDefault(p => p.Nombre == nombreProducto);

                CargaVenta carga = new CargaVenta
                {
                    IdCliente = idCliente,
                    IdUsuario = idUsuario,
                    IdProducto = producto.Id,
                    Cantidad = Convert.ToInt32(fila.Cells["colCantidad"].Value)
                };

                string respuesta = ventaPersistencia.agregarVenta(carga);

                if (respuesta != null && respuesta.StartsWith("ERROR"))
                {
                    errores += $"Error con producto {nombreProducto}:\n{respuesta}\n\n";
                }
            }

            if (string.IsNullOrEmpty(errores))
            {
                MessageBox.Show("¡Venta registrada con éxito!");
                dgvCarrito.Rows.Clear();
                ActualizarTotales();
                btnConfirmarVenta.Enabled = false;
            }
            else
            {
                MessageBox.Show("Se produjeron errores:\n\n" + errores);
            }
        }
        private void lstProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblSubtotal_Click(object sender, EventArgs e)
        {

        }
    }
}
