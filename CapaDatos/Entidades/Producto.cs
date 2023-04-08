using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CapaDatos.Entidades
{
    
    public class Producto
    {
        [Display(Name = "ID")]
        public int IdProducto { get; set; }

        [Display(Name = "Nombre")]
        public string NomProducto { get; set; }

        [Display(Name = "Marca")]
        public int MarcaProducto { get; set; }

        [Display(Name = "Precio")]
        public decimal CostoProducto { get; set; }

    }
}
