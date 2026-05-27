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
            var lista = iConexion.Ventas_Peliculas!.ToList();
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Ventas_Peliculas", Accion = "Consultar", Fecha = DateTime.Now, DatosNuevos = "Se consultaron registros de Ventas_Peliculas" });
            iConexion.SaveChanges();
            return lista;
        }

        public Ventas_Peliculas Guardar(Ventas_Peliculas entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            if (entidad.Cantidad <= 0) throw new Exception("La cantidad debe ser mayor a cero.");
            if (entidad.Precio_U <= 0) throw new Exception("El precio unitario debe ser mayor a cero.");
            entidad.Subtotal = entidad.Cantidad * entidad.Precio_U;
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Ventas_Peliculas!.Add(entidad);
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Ventas_Peliculas", Accion = "Guardar", Fecha = DateTime.Now, DatosNuevos = "Subtotal calculado: " + entidad.Subtotal });
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
