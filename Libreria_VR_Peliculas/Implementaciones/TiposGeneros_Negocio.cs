using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class TiposGeneros_Negocio : ITiposGeneros_Negocio
    {
        private IConexion? iConexion;

        public List<TiposGeneros> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.TiposGeneros!.ToList();
            var audit = new Auditorias { Tabla = "TiposGeneros", Accion = "Consultar", Fecha = DateTime.Now, DatosAnteriores = null, DatosNuevos = "Se consultaron registros de TiposGeneros" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return lista;
        }

        public TiposGeneros Guardar(TiposGeneros entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.TiposGeneros!.Add(entidad);
            var audit = new Auditorias { Tabla = "TiposGeneros", Accion = "Guardar", Fecha = DateTime.Now, DatosAnteriores = null, DatosNuevos = "Se guardó un registro en TiposGeneros" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }

        public TiposGeneros Modificar(TiposGeneros entidad)
        {
            if (entidad.Id == 0) throw new Exception("El registro no tiene un ID válido.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entry = iConexion.Entry<TiposGeneros>(entidad);
            entry.State = EntityState.Modified;
            var audit = new Auditorias { Tabla = "TiposGeneros", Accion = "Modificar", Fecha = DateTime.Now, DatosAnteriores = "Id: " + entidad.Id, DatosNuevos = "Se modificó registro Id:"+ entidad.Id+" en TiposGeneros" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
