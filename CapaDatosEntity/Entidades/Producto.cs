namespace CapaDatosEntity.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        [StringLength(50)]
        public string NomProducto { get; set; }

        public int MarcaProducto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CostoProducto { get; set; }
    }
}
