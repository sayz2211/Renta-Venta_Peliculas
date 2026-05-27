using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Facturas_Negocio : IFacturas_Negocio
    {
        private IConexion? iConexion;

        public List<Facturas> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Facturas!.ToList();
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Facturas", Accion = "Consultar", Fecha = DateTime.Now, DatosNuevos = "Se consultaron registros de Facturas" });
            iConexion.SaveChanges();
            return lista;
        }

        public Facturas Guardar(Facturas entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            if (entidad.Total <= 0) throw new Exception("El total debe ser mayor a cero.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            if (entidad.Descuentos != null && entidad.Descuentos > 0)
            {
                var descuento = iConexion.Descuentos!.FirstOrDefault(d => d.Id == entidad.Descuentos);
                if (descuento != null && descuento.Activo)
                    entidad.Total = entidad.Total - (entidad.Total * descuento.Porcentaje / 100);
            }
            if (string.IsNullOrEmpty(entidad.Codigo))
                entidad.Codigo = "FAC-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            iConexion.Facturas!.Add(entidad);
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Facturas", Accion = "Guardar", Fecha = DateTime.Now, DatosNuevos = "Factura " + entidad.Codigo + " total: " + entidad.Total });
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
