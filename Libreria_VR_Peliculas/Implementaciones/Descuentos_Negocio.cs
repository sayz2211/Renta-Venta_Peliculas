using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Descuentos_Negocio : IDescuentos_Negocio
    {
        private IConexion? iConexion;

        public List<Descuentos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Descuentos!.ToList();
            var audit = new Auditorias { Tabla = "Descuentos", Accion = "Consultar", Fecha = DateTime.Now, DatosAnteriores = null, DatosNuevos = "Se consultaron registros de Descuentos" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return lista;
        }

        public Descuentos Guardar(Descuentos entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Descuentos!.Add(entidad);
            var audit = new Auditorias { Tabla = "Descuentos", Accion = "Guardar", Fecha = DateTime.Now, DatosAnteriores = null, DatosNuevos = "Se guardó un registro en Descuentos" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }

        public Descuentos Modificar(Descuentos entidad)
        {
            if (entidad.Id == 0) throw new Exception("El registro no tiene un ID válido.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entry = iConexion.Entry<Descuentos>(entidad);
            entry.State = EntityState.Modified;
            var audit = new Auditorias { Tabla = "Descuentos", Accion = "Modificar", Fecha = DateTime.Now, DatosAnteriores = "Id:" + entidad.Id + " ", DatosNuevos = "Se modificó registro " + entidad.Id +  " en Descuentos" };
            iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
