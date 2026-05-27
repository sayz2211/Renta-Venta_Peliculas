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
            if (entidad.Fecha_Limite <= entidad.Fecha_Renta) throw new Exception("La fecha límite debe ser mayor a la fecha de renta.");
            if (entidad.Precio_Dia <= 0) throw new Exception("El precio por día debe ser mayor a cero.");
            if (entidad.Cantidad <= 0) throw new Exception("La cantidad debe ser mayor a cero.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Rentas!.Add(entidad);
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Rentas", Accion = "Guardar", Fecha = DateTime.Now, DatosNuevos = "Renta registrada: " + entidad.Fecha_Renta.ToString("yyyy-MM-dd") });
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
