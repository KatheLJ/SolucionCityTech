using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using CapaDatosEntity.Entidades;

namespace CapaDatosEntity
{
    public partial class ModelLagar : DbContext
    {
        public ModelLagar()
            : base("name=ModelLagar")
        {
        }

        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(e => e.NomProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.CostoProducto)
                .HasPrecision(17, 2);
        }
    }
}
