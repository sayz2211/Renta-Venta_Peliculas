using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Formatos_Peliculas_Negocio : IFormatos_Peliculas_Negocio
    {
        private IConexion? iConexion;

        public List<Formatos_Peliculas> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Formatos_Peliculas!.ToList();
            var audit = new Auditorias { Tabla = "Formatos_Peliculas", Accion = "Consultar", Fecha = DateTime.Now, DatosAnteriores = null, DatosNuevos = "Se consultaron registros de Formatos_Peliculas" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return lista;
        }

        public Formatos_Peliculas Guardar(Formatos_Peliculas entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Formatos_Peliculas!.Add(entidad);
            var audit = new Auditorias { Tabla = "Formatos_Peliculas", Accion = "Guardar", Fecha = DateTime.Now, DatosAnteriores = null, DatosNuevos = "Se guardó un registro en Formatos_Peliculas" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }

        public Formatos_Peliculas Modificar(Formatos_Peliculas entidad)
        {
            if (entidad.Id == 0) throw new Exception("El registro no tiene un ID válido.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entry = iConexion.Entry<Formatos_Peliculas>(entidad);
            entry.State = EntityState.Modified;
            var audit = new Auditorias { Tabla = "Formatos_Peliculas", Accion = "Modificar", Fecha = DateTime.Now, DatosAnteriores = "Id: " + entidad.Id, DatosNuevos = "Se modificó registro Id:"+ entidad.Id+" en Formatos_Peliculas" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
