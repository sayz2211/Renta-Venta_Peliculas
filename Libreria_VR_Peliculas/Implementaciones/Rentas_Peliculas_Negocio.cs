using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Rentas_Peliculas_Negocio : IRentas_Peliculas_Negocio
    {
        private IConexion? iConexion;

        public List<Rentas_Peliculas> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            return iConexion.Rentas_Peliculas!.ToList();
        }

        public Rentas_Peliculas Guardar(Rentas_Peliculas entidad)
        {
            if (entidad.Rentas == null || entidad.Rentas == 0) throw new Exception("Debe seleccionar una Renta válida.");
            if (entidad.Peliculas == null || entidad.Peliculas == 0) throw new Exception("Debe seleccionar una Película.");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            // Calcular subtotal correcto: Cantidad x Dias x Precio_Dia
            if (entidad.Subtotal <= 0)
                entidad.Subtotal = entidad.Cantidad * entidad.Dias * entidad.Precio_Dia;

            // 1. Guardar el detalle de la renta
            iConexion.Rentas_Peliculas!.Add(entidad);
            iConexion.SaveChanges();

            // 2. Recalcular y actualizar el Total de la Factura asociada a esta Renta
            var factura = iConexion.Facturas!.FirstOrDefault(f => f.Rentas == entidad.Rentas);
            if (factura != null)
            {
                factura.Total = iConexion.Rentas_Peliculas!
                    .Where(rp => rp.Rentas == entidad.Rentas)
                    .Sum(rp => rp.Subtotal);

                iConexion.Facturas.Update(factura);
            }

            iConexion.Auditorias!.Add(new Auditorias
            {
                Tabla = "Rentas_Peliculas",
                Accion = "Guardar Detalle + Actualizar Factura",
                Fecha = DateTime.Now,
                DatosNuevos = "Renta ID: " + entidad.Rentas + " | Película ID: " + entidad.Peliculas + " | Nuevo Total Factura: " + factura?.Total
            });

            iConexion.SaveChanges();
            return entidad;
        }
    }
}
