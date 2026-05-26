using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Membresias_Negocio : IMembresias_Negocio
    {
        private IConexion? iConexion;

        public List<Membresias> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Membresias!.ToList();
            var audit = new Auditorias { Tabla = "Membresias", Accion = "Consultar", Fecha = DateTime.Now, DatosAnteriores = null, DatosNuevos = "Se consultaron registros de Membresias" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return lista;
        }

        public Membresias Guardar(Membresias entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Membresias!.Add(entidad);
            var audit = new Auditorias { Tabla = "Membresias", Accion = "Guardar", Fecha = DateTime.Now, DatosAnteriores = null, DatosNuevos = "Se guardó un registro en Membresias" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }

        public Membresias Modificar(Membresias entidad)
        {
            if (entidad.Id == 0) throw new Exception("El registro no tiene un ID válido.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entry = iConexion.Entry<Membresias>(entidad);
            entry.State = EntityState.Modified;
            var audit = new Auditorias { Tabla = "Membresias", Accion = "Modificar", Fecha = DateTime.Now, DatosAnteriores = "Id: " + entidad.Id, DatosNuevos = "Se modificó registro Id:"+ entidad.Id+" en Membresias" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
