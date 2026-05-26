using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Sucursales_Negocio : ISucursales_Negocio
    {
        private IConexion? iConexion;

        public List<Sucursales> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Sucursales!.ToList();
            var audit = new Auditorias { Tabla = "Sucursales", Accion = "Consultar", Fecha = DateTime.Now, DatosAnteriores = null, DatosNuevos = "Se consultaron registros de Sucursales" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return lista;
        }

        public Sucursales Guardar(Sucursales entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Sucursales!.Add(entidad);
            var audit = new Auditorias { Tabla = "Sucursales", Accion = "Guardar", Fecha = DateTime.Now, DatosAnteriores = null, DatosNuevos = "Se guardó un registro en Sucursales" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }

        public Sucursales Modificar(Sucursales entidad)
        {
            if (entidad.Id == 0) throw new Exception("El registro no tiene un ID válido.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entry = iConexion.Entry<Sucursales>(entidad);
            entry.State = EntityState.Modified;
            var audit = new Auditorias { Tabla = "Sucursales", Accion = "Modificar", Fecha = DateTime.Now, DatosAnteriores = "Id: " + entidad.Id, DatosNuevos = "Se modificó registro Id:"+ entidad.Id+" en Sucursales" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }

        public Sucursales Eliminar(Sucursales entidad)
        {
            if (entidad.Id == 0) throw new Exception("El registro no tiene un ID válido.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Sucursales!.Remove(entidad);
            var audit = new Auditorias { Tabla = "Sucursales", Accion = "Eliminar", Fecha = DateTime.Now, DatosAnteriores = "Id: " + entidad.Id, DatosNuevos = null };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
