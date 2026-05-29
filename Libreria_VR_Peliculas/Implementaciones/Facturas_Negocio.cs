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
            // Las facturas se crean automáticamente al guardar una Renta o Venta.
            // Este método permite editar manualmente una factura existente (ej: aplicar descuento).
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var existente = iConexion.Facturas!.FirstOrDefault(f => f.Id == entidad.Id);
            if (existente == null) throw new Exception("Factura no encontrada. Las facturas se generan automáticamente al crear una Renta o Venta.");

            // Aplicar descuento si se seleccionó uno
            if (entidad.Descuentos != null && entidad.Descuentos > 0)
            {
                var descuento = iConexion.Descuentos!.FirstOrDefault(d => d.Id == entidad.Descuentos);
                if (descuento != null && descuento.Activo)
                {
                    // Recalcular el total base desde los detalles antes de aplicar descuento
                    decimal totalBase = 0;
                    if (existente.Rentas != null)
                        totalBase = iConexion.Rentas_Peliculas!.Where(rp => rp.Rentas == existente.Rentas).Sum(rp => rp.Subtotal);
                    else if (existente.Ventas != null)
                        totalBase = iConexion.Ventas_Peliculas!.Where(vp => vp.Ventas == existente.Ventas).Sum(vp => vp.Subtotal);

                    existente.Total = totalBase - (totalBase * descuento.Porcentaje / 100);
                    existente.Descuentos = entidad.Descuentos;
                }
            }

            iConexion.Facturas.Update(existente);
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Facturas", Accion = "Actualizar", Fecha = DateTime.Now, DatosNuevos = "Factura ID: " + existente.Id + " | Total: " + existente.Total });
            iConexion.SaveChanges();
            return existente;
        }
    }
}
