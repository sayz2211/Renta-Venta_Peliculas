using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;

namespace PruebasVR_peliculas
{
    /// <summary>
    /// Pruebas de comunicaciones — verifican que la API REST responda correctamente.
    /// La API debe estar ENCENDIDA en puerto 5103 para estas pruebas.
    /// </summary>

    [TestClass]
    public class Comunicacion_Peliculas_Consultar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IPeliculas_Presentacion iPeliculas = new Peliculas_Presentacion();
            var lista = iPeliculas.Consultar();
            if (lista != null && lista.Count > 0)
                return;
            throw new Exception("La API no retornó películas.");
        }
    }

    [TestClass]
    public class Comunicacion_Peliculas_Guardar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IPeliculas_Presentacion iPeliculas = new Peliculas_Presentacion();
            var nueva = new Peliculas
            {
                Nombre = "Pelicula Test API",
                Estreno = "2026",
                Clasi_edad = "PG",
                Puntuacion = 7,
                Disponibilidad = true
            };
            var resultado = iPeliculas.Guardar(nueva);
            iPeliculas.Eliminar(resultado);
            if (resultado.Id > 0)
                return;
            throw new Exception("La API no retornó la película con ID asignado.");
        }
    }

    [TestClass]
    public class Comunicacion_Clientes_Consultar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IClientes_Presentacion iClientes = new Clientes_Presentacion();
            var lista = iClientes.Consultar();
            if (lista != null && lista.Count > 0)
                return;
            throw new Exception("La API no retornó clientes.");
        }
    }

    [TestClass]
    public class Comunicacion_Clientes_Guardar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IClientes_Presentacion iClientes = new Clientes_Presentacion();
            var nuevo = new Clientes
            {
                Nombre = "Cliente Test API",
                Cedula = "999999999",
                Correo = "test@api.com",
                Telefono = "3111111111"
            };
            var resultado = iClientes.Guardar(nuevo);
            iClientes.Eliminar(resultado);
            if (resultado.Id > 0)
                return;
            throw new Exception("La API no retornó el cliente con ID asignado.");
        }
    }

    [TestClass]
    public class Comunicacion_Actores_Consultar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IActores_Presentacion iActores = new Actores_Presentacion();
            var lista = iActores.Consultar();
            if (lista != null && lista.Count > 0)
                return;
            throw new Exception("La API no retornó actores.");
        }
    }

    [TestClass]
    public class Comunicacion_Directores_Consultar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IDirectores_Presentacion iDirectores = new Directores_Presentacion();
            var lista = iDirectores.Consultar();
            if (lista != null && lista.Count > 0)
                return;
            throw new Exception("La API no retornó directores.");
        }
    }

    [TestClass]
    public class Comunicacion_Rentas_Consultar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IRentas_Presentacion iRentas = new Rentas_Presentacion();
            var lista = iRentas.Consultar();
            if (lista != null && lista.Count > 0)
                return;
            throw new Exception("La API no retornó rentas.");
        }
    }

    [TestClass]
    public class Comunicacion_Ventas_Consultar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IVentas_Presentacion iVentas = new Ventas_Presentacion();
            var lista = iVentas.Consultar();
            if (lista != null && lista.Count > 0)
                return;
            throw new Exception("La API no retornó ventas.");
        }
    }

    [TestClass]
    public class Comunicacion_Facturas_Consultar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IFacturas_Presentacion iFacturas = new Facturas_Presentacion();
            var lista = iFacturas.Consultar();
            if (lista != null && lista.Count > 0)
                return;
            throw new Exception("La API no retornó facturas.");
        }
    }

    [TestClass]
    public class Comunicacion_Usuarios_Consultar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IUsuarios_Presentacion iUsuarios = new Usuarios_Presentacion();
            var lista = iUsuarios.Consultar();
            if (lista != null && lista.Count > 0)
                return;
            throw new Exception("La API no retornó usuarios.");
        }
    }

    [TestClass]
    public class Comunicacion_Roles_Consultar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IRoles_Presentacion iRoles = new Roles_Presentacion();
            var lista = iRoles.Consultar();
            if (lista != null && lista.Count > 0)
                return;
            throw new Exception("La API no retornó roles.");
        }
    }

    [TestClass]
    public class Comunicacion_Inventarios_Consultar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IInventarios_Presentacion iInventarios = new Inventarios_Presentacion();
            var lista = iInventarios.Consultar();
            if (lista != null && lista.Count > 0)
                return;
            throw new Exception("La API no retornó inventarios.");
        }
    }

    [TestClass]
    public class Comunicacion_RentasPeliculas_Consultar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IRentas_Peliculas_Presentacion iRentasPelis = new Rentas_Peliculas_Presentacion();
            var lista = iRentasPelis.Consultar();
            if (lista != null && lista.Count > 0)
                return;
            throw new Exception("La API no retornó rentas películas.");
        }
    }

    [TestClass]
    public class Comunicacion_VentasPeliculas_Consultar
    {
        [TestMethod]
        public void Ejecutar()
        {
            IVentas_Peliculas_Presentacion iVentasPelis = new Ventas_Peliculas_Presentacion();
            var lista = iVentasPelis.Consultar();
            if (lista != null && lista.Count > 0)
                return;
            throw new Exception("La API no retornó ventas películas.");
        }
    }

    [TestClass]
    public class Comunicacion_FlujoCompleto_RentaConFactura
    {
        [TestMethod]
        public void Ejecutar()
        {
       
            IClientes_Presentacion iClientes = new Clientes_Presentacion();
            var clientes = iClientes.Consultar();
            if (clientes == null || clientes.Count == 0)
                throw new Exception("No hay clientes para crear la renta.");

            IRentas_Presentacion iRentas = new Rentas_Presentacion();
            var renta = new Rentas
            {
                Clientes = clientes.First().Id,
                Fecha_Renta = DateTime.Now,
                Fecha_Limite = DateTime.Now.AddDays(3),
                Precio_Dia = 1,
                Cantidad = 1
            };
            var rentaGuardada = iRentas.Guardar(renta);
            if (rentaGuardada.Id <= 0)
                throw new Exception("La renta no se guardó correctamente.");

          
            IFacturas_Presentacion iFacturas = new Facturas_Presentacion();
            var facturas = iFacturas.Consultar();
            var facturaCreada = facturas?.FirstOrDefault(f => f.Rentas == rentaGuardada.Id);

            if (facturas == null)
                throw new Exception("La API no retornó la lista de facturas.");
            if (facturaCreada != null)
                return;
            throw new Exception("Al guardar la renta no se generó su factura automáticamente.");
        }
    }
}
