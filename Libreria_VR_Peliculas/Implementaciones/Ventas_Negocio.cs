using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Ventas_Negocio : IVentas_Negocio
    {
        private IConexion? iConexion;

        public List<Ventas> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Ventas!.ToList();
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Ventas", Accion = "Consultar", Fecha = DateTime.Now, DatosNuevos = "Se consultaron registros de Ventas" });
            iConexion.SaveChanges();
            return lista;
        }

        public Ventas Guardar(Ventas entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            if (entidad.Clientes == null || entidad.Clientes == 0) throw new Exception("Debe seleccionar un Cliente válido.");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            // 1. Guardar la venta para obtener el Id generado
            iConexion.Ventas!.Add(entidad);
            iConexion.SaveChanges();

            // 2. Crear la factura con Total = 0 (se actualizará al agregar Ventas_Peliculas)
            Facturas facturaVenta = new Facturas
            {
                Codigo = "FAC-V-" + entidad.Id,
                Fecha = DateTime.Now,
                Clientes = entidad.Clientes,
                Ventas = entidad.Id,
                Rentas = null,
                Descuentos = null,
                Total = 0
            };
            iConexion.Facturas!.Add(facturaVenta);

            iConexion.Auditorias!.Add(new Auditorias
            {
                Tabla = "Ventas",
                Accion = "Guardar + Factura creada en $0",
                Fecha = DateTime.Now,
                DatosNuevos = "Venta ID: " + entidad.Id + " — El total se actualizará al agregar películas."
            });

            iConexion.SaveChanges();
            return entidad;
        }
    }
}
