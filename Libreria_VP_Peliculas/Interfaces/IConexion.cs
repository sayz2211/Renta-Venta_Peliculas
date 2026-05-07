using Libreria_VR_Peliculas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IConexion
    {
        string? string_conexion { get; set; }

        DbSet<Actores>? Actores { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Descuentos>? Descuentos { get; set; }
        DbSet<Devoluciones>? Devoluciones { get; set; }
        DbSet<Directores>? Directores { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Facturas>? Facturas { get; set; }
        DbSet<Formatos>? Formatos { get; set; }
        DbSet<Formatos_Peliculas>? Formatos_Peliculas { get; set; }
        DbSet<Inventarios>? Inventarios { get; set; }
        DbSet<Peliculas>? Peliculas { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Reclamos>? Reclamos { get; set; }
        DbSet<Rentas>? Rentas { get; set; }
        DbSet<Rentas_Peliculas>? Rentas_Peliculas { get; set; }
        DbSet<Repartos>? Repartos { get; set; }
        DbSet<Status>? Status { get; set; }
        DbSet<Sucursales>? Sucursales { get; set; }
        DbSet<TiposGeneros>? TiposGeneros { get; set; }
        DbSet<Ventas>? Ventas { get; set; }
        DbSet<Ventas_Peliculas>? Ventas_Peliculas { get; set; }


        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}