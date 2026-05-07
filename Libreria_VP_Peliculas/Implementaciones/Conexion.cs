
using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? string_conexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.string_conexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Actores>? Actores { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Descuentos>? Descuentos { get; set; }
        public DbSet<Devoluciones>? Devoluciones { get; set; }
        public DbSet<Directores>? Directores { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<Formatos>? Formatos { get; set; }
        public DbSet<Formatos_Peliculas>? Formatos_Peliculas { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Peliculas>? Peliculas { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Reclamos>? Reclamos { get; set; }
        public DbSet<Rentas>? Rentas { get; set; }
        public DbSet<Rentas_Peliculas>? Rentas_Peliculas { get; set; }
        public DbSet<Repartos>? Repartos { get; set; }
        public DbSet<Status>? Status { get; set; }
        public DbSet<Sucursales>? Sucursales { get; set; }
        public DbSet<TiposGeneros>? TiposGeneros { get; set; }
        public DbSet<Ventas>? Ventas { get; set; }
        public DbSet<Ventas_Peliculas>? Ventas_Peliculas { get; set; }

    }
}
