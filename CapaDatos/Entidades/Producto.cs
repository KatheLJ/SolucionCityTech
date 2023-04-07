using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel;


namespace CapaDatos.Entidades
{
    
    public class Producto
    {
        public int IdProducto { get; set; }

        public string NomProducto { get; set; }

        public int MarcaProducto { get; set; }

        public decimal CostoProducto { get; set; }

    }
}
