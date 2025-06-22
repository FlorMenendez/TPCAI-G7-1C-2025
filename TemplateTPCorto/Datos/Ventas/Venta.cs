using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{
    public class Venta
    {
        public Guid IdCliente { get; set; }
        public List<DetalleVenta> Detalles { get; set; }
    }
}
