﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{
    public class DetalleVenta
    {
        public Guid IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }
    }
}
