using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Ventas_Peliculas_Negocio : IVentas_Peliculas_Negocio
    {
        private IConexion? iConexion;

        public List<Ventas_Peliculas> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            return iConexion.Ventas_Peliculas!.ToList();
        }

        public Ventas_Peliculas Guardar(Ventas_Peliculas entidad)
        {
            if (entidad.Ventas == null || entidad.Ventas == 0) throw new Exception("Debe estar vinculado a una Venta.");
            if (entidad.Peliculas == null || entidad.Peliculas == 0) throw new Exception("Debe seleccionar una Película.");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            // Calcular subtotal correcto: Cantidad x Precio_U
            if (entidad.Subtotal <= 0)
                entidad.Subtotal = entidad.Cantidad * entidad.Precio_U;

            // 1. Guardar el detalle de la venta
            iConexion.Ventas_Peliculas!.Add(entidad);
            iConexion.SaveChanges();

            // 2. Recalcular y actualizar el Total de la Factura asociada a esta Venta
            var factura = iConexion.Facturas!.FirstOrDefault(f => f.Ventas == entidad.Ventas);
            if (factura != null)
            {
                factura.Total = iConexion.Ventas_Peliculas!
                    .Where(vp => vp.Ventas == entidad.Ventas)
                    .Sum(vp => vp.Subtotal);

                iConexion.Facturas.Update(factura);
            }

            iConexion.Auditorias!.Add(new Auditorias
            {
                Tabla = "Ventas_Peliculas",
                Accion = "Guardar Detalle + Actualizar Factura",
                Fecha = DateTime.Now,
                DatosNuevos = "Venta ID: " + entidad.Ventas + " | Película ID: " + entidad.Peliculas + " | Nuevo Total Factura: " + factura?.Total
            });

            iConexion.SaveChanges();
            return entidad;
        }
    }
}
