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
            if (entidad.Cantidad <= 0) throw new Exception("La cantidad debe ser mayor a cero.");
            if (entidad.Precio_Venta <= 0) throw new Exception("El precio de venta debe ser mayor a cero.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Ventas!.Add(entidad);
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Ventas", Accion = "Guardar", Fecha = DateTime.Now, DatosNuevos = "Venta registrada por valor: " + entidad.Precio_Venta });
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
