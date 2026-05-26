using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Proveedores_Negocio : IProveedores_Negocio
    {
        private IConexion? iConexion;

        public List<Proveedores> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Proveedores!.ToList();
            var audit = new Auditorias { Tabla = "Proveedores", Accion = "Consultar", Fecha = DateTime.Now, DatosAnteriores = null, DatosNuevos = "Se consultaron registros de Proveedores" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return lista;
        }

        public Proveedores Guardar(Proveedores entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Proveedores!.Add(entidad);
            var audit = new Auditorias { Tabla = "Proveedores", Accion = "Guardar", Fecha = DateTime.Now, DatosAnteriores = null, DatosNuevos = "Se guardó un registro en Proveedores" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }

        public Proveedores Modificar(Proveedores entidad)
        {
            if (entidad.Id == 0) throw new Exception("El registro no tiene un ID válido.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entry = iConexion.Entry<Proveedores>(entidad);
            entry.State = EntityState.Modified;
            var audit = new Auditorias { Tabla = "Proveedores", Accion = "Modificar", Fecha = DateTime.Now, DatosAnteriores = "Id: " + entidad.Id, DatosNuevos = "Se modificó registro Id:"+ entidad.Id+" en Proveedores" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }

        public Proveedores Eliminar(Proveedores entidad)
        {
            if (entidad.Id == 0) throw new Exception("El registro no tiene un ID válido.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Proveedores!.Remove(entidad);
            var audit = new Auditorias { Tabla = "Proveedores", Accion = "Eliminar", Fecha = DateTime.Now, DatosAnteriores = "Id: " + entidad.Id, DatosNuevos = null };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
