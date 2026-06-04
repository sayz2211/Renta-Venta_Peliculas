using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;
using Microsoft.Data.SqlClient;
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
            var audit = new Auditorias {  };
            iConexion.Auditorias!.Add(audit);
            try
            {
                iConexion.SaveChanges();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sql && sql.Number == 515)
            {
                throw new Exception("Hay campos obligatorios vacíos. Verifique los datos.");
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sql && sql.Number == 8152)
            {
                throw new Exception("Uno de los campos supera la longitud permitida.");
            }
            catch (DbUpdateException)
            {
                throw new Exception("Error al guardar el proveedor. Verifique los datos ingresados.");
            }
            return entidad;
        }


        public Proveedores Modificar(Proveedores entidad)
        {
            if (entidad.Id == 0) throw new Exception("El registro no tiene un ID válido.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entry = iConexion.Entry<Proveedores>(entidad);
            entry.State = EntityState.Modified;
            var audit = new Auditorias {  };
            iConexion.Auditorias!.Add(audit);
            try
            {
                iConexion.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("El registro fue modificado por otro usuario. Recargue e intente de nuevo.");
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sql && sql.Number == 515)
            {
                throw new Exception("Hay campos obligatorios vacíos. Verifique los datos.");
            }
            catch (DbUpdateException)
            {
                throw new Exception("Error al modificar el proveedor. Verifique los datos ingresados.");
            }
            return entidad;
        }

    
        public Proveedores Eliminar(Proveedores entidad)
        {
            if (entidad.Id == 0) throw new Exception("El registro no tiene un ID válido.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Proveedores!.Remove(entidad);
            var audit = new Auditorias {  };
            iConexion.Auditorias!.Add(audit);
            try
            {
                iConexion.SaveChanges();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sql && sql.Number == 547)
            {
                throw new Exception("No se puede eliminar porque tiene registros asociados en otras tablas.");
            }
            catch (DbUpdateException)
            {
                throw new Exception("Error al eliminar el proveedor.");
            }
            return entidad;
        }
    }
}
