using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Devoluciones_Negocio : IDevoluciones_Negocio
    {
        private IConexion? iConexion;

        public List<Devoluciones> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Devoluciones!.ToList();
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Devoluciones", Accion = "Consultar", Fecha = DateTime.Now, DatosNuevos = "Se consultaron registros de Devoluciones" });
            iConexion.SaveChanges();
            return lista;
        }

        public Devoluciones Guardar(Devoluciones entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var factura = iConexion.Facturas!.FirstOrDefault(f => f.Id == entidad.Facturas);
            if (factura != null && factura.Rentas != null && factura.Rentas > 0)
            {
                var renta = iConexion.Rentas!.FirstOrDefault(r => r.Id == factura.Rentas);
                if (renta != null && entidad.Fecha > renta.Fecha_Limite)
                {
                    var diasRetraso = (entidad.Fecha - renta.Fecha_Limite).Days;
                    entidad.Precio_Multa = diasRetraso * renta.Precio_Dia;
                    entidad.Multa = "Entrega tardía: " + diasRetraso + " días de retraso";
                }
                else
                {
                    entidad.Precio_Multa = 0;
                    entidad.Multa = "Sin multa";
                }
            }
            iConexion.Devoluciones!.Add(entidad);
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Devoluciones", Accion = "Guardar", Fecha = DateTime.Now, DatosNuevos = "Devolución registrada. Multa: " + entidad.Precio_Multa });
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
