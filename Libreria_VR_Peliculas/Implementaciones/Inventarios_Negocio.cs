using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Inventarios_Negocio : IInventarios_Negocio
    {
        private IConexion? iConexion;

        public List<Inventarios> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Inventarios!.ToList();
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Inventarios", Accion = "Consultar", Fecha = DateTime.Now, DatosNuevos = "Se consultaron registros de Inventarios" });
            iConexion.SaveChanges();
            return lista;
        }

        public Inventarios Guardar(Inventarios entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            if (entidad.Cantidad < 0) throw new Exception("La cantidad no puede ser negativa.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Inventarios!.Add(entidad);
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Inventarios", Accion = "Guardar", Fecha = DateTime.Now, DatosNuevos = "Inventario registrado cantidad: " + entidad.Cantidad });
            iConexion.SaveChanges();
            return entidad;
        }

        public Inventarios Modificar(Inventarios entidad)
        {
            if (entidad.Id == 0) throw new Exception("El registro no tiene un ID válido.");
            if (entidad.Cantidad < 0) throw new Exception("La cantidad no puede ser negativa.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entry = iConexion.Entry<Inventarios>(entidad);
            entry.State = EntityState.Modified;
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Inventarios", Accion = "Modificar", Fecha = DateTime.Now, DatosAnteriores = "Id: " + entidad.Id, DatosNuevos = "Nueva cantidad: " + entidad.Cantidad });
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
