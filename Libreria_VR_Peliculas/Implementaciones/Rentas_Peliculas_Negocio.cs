using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Rentas_Peliculas_Negocio : IRentas_Peliculas_Negocio
    {
        private IConexion? iConexion;

        public List<Rentas_Peliculas> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Rentas_Peliculas!.ToList();
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Rentas_Peliculas", Accion = "Consultar", Fecha = DateTime.Now, DatosNuevos = "Se consultaron registros de Rentas_Peliculas" });
            iConexion.SaveChanges();
            return lista;
        }

        public Rentas_Peliculas Guardar(Rentas_Peliculas entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            if (entidad.Dias <= 0) throw new Exception("Los días deben ser mayor a cero.");
            if (entidad.Precio_Dia <= 0) throw new Exception("El precio por día debe ser mayor a cero.");
            if (entidad.Cantidad <= 0) throw new Exception("La cantidad debe ser mayor a cero.");
            entidad.Subtotal = entidad.Cantidad * entidad.Dias * entidad.Precio_Dia;
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Rentas_Peliculas!.Add(entidad);
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Rentas_Peliculas", Accion = "Guardar", Fecha = DateTime.Now, DatosNuevos = "Subtotal calculado: " + entidad.Subtotal });
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
