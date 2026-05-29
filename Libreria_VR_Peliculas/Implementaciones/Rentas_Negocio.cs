using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Rentas_Negocio : IRentas_Negocio
    {
        private IConexion? iConexion;

        public List<Rentas> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Rentas!.ToList();
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Rentas", Accion = "Consultar", Fecha = DateTime.Now, DatosNuevos = "Se consultaron registros de Rentas" });
            iConexion.SaveChanges();
            return lista;
        }

        public Rentas Guardar(Rentas entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            if (entidad.Clientes == null || entidad.Clientes == 0) throw new Exception("Debe seleccionar un Cliente válido.");
            if (entidad.Fecha_Renta == default) throw new Exception("La fecha de renta no es válida.");
            if (entidad.Fecha_Limite <= entidad.Fecha_Renta) throw new Exception("La fecha límite debe ser mayor a la fecha de renta.");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            // 1. Guardar la renta para obtener el Id generado
            iConexion.Rentas!.Add(entidad);
            iConexion.SaveChanges();

            // 2. Crear la factura con Total = 0 (se actualizará al agregar Rentas_Peliculas)
            Facturas nuevaFactura = new Facturas
            {
                Codigo = "FAC-R-" + entidad.Id,
                Fecha = DateTime.Now,
                Clientes = entidad.Clientes,
                Rentas = entidad.Id,
                Ventas = null,
                Descuentos = null,
                Total = 0
            };
            iConexion.Facturas!.Add(nuevaFactura);

            iConexion.Auditorias!.Add(new Auditorias
            {
                Tabla = "Rentas",
                Accion = "Guardar + Factura creada en $0",
                Fecha = DateTime.Now,
                DatosNuevos = "Renta ID: " + entidad.Id + " — El total se actualizará al agregar películas."
            });

            iConexion.SaveChanges();
            return entidad;
        }
    }
}
