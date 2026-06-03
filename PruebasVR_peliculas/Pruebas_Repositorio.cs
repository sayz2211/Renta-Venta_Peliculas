using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;
using Libreria_VR_Peliculas.Implementaciones;
using static Libreria_VR_Peliculas.Nucleo.Configuraciones;

namespace PruebasVR_peliculas
{
    /// <summary>
    /// Pruebas de repositorio — conexión directa a la base de datos via Entity Framework.
    /// La API debe estar APAGADA al correr estas pruebas.
    /// </summary>

    [TestClass]
    public class Repositorio_Peliculas
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var lista = conexion.Peliculas!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("La tabla Peliculas no tiene registros.");
        }
    }

    [TestClass]
    public class Repositorio_Clientes
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var lista = conexion.Clientes!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("La tabla Clientes no tiene registros.");
        }
    }

    [TestClass]
    public class Repositorio_Usuarios
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var lista = conexion.Usuarios!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("La tabla Usuarios no tiene registros.");
        }
    }

    [TestClass]
    public class Repositorio_Roles
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var lista = conexion.Roles!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("La tabla Roles no tiene registros.");
        }
    }

    [TestClass]
    public class Repositorio_Actores
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var lista = conexion.Actores!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("La tabla Actores no tiene registros.");
        }
    }

    [TestClass]
    public class Repositorio_Directores
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var lista = conexion.Directores!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("La tabla Directores no tiene registros.");
        }
    }

    [TestClass]
    public class Repositorio_Rentas
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var lista = conexion.Rentas!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("La tabla Rentas no tiene registros.");
        }
    }

    [TestClass]
    public class Repositorio_Ventas
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var lista = conexion.Ventas!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("La tabla Ventas no tiene registros.");
        }
    }

    [TestClass]
    public class Repositorio_Facturas
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var lista = conexion.Facturas!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("La tabla Facturas no tiene registros.");
        }
    }

    [TestClass]
    public class Repositorio_Inventarios
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var lista = conexion.Inventarios!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("La tabla Inventarios no tiene registros.");
        }
    }

    [TestClass]
    public class Repositorio_Auditorias
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var lista = conexion.Auditorias!.ToList();
            if (lista != null)
                return;
            throw new Exception("No se pudo consultar la tabla Auditorias.");
        }
    }

    [TestClass]
    public class Repositorio_Guardar_Pelicula
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var nueva = new Peliculas
            {
                Nombre = "Prueba Repositorio",
                Estreno = "2026",
                Clasi_edad = "PG",
                Puntuacion = 5,
                Disponibilidad = true
            };
            conexion.Peliculas!.Add(nueva);
            conexion.SaveChanges();
            conexion.Peliculas.Remove(nueva);
            conexion.SaveChanges();
            if (nueva.Id > 0)
                return;
            throw new Exception("La película no obtuvo ID al guardarse en BD.");
        }
    }

    [TestClass]
    public class Repositorio_Guardar_Cliente
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var nuevo = new Clientes
            {
                Nombre = "Cliente Prueba BD",
                Cedula = "000000000",
                Correo = "pruebabd@test.com",
                Telefono = "3000000000"
            };
            conexion.Clientes!.Add(nuevo);
            conexion.SaveChanges();
            conexion.Clientes.Remove(nuevo);
            conexion.SaveChanges();
            if (nuevo.Id > 0)
                return;
            throw new Exception("El cliente no obtuvo ID al guardarse en BD.");
        }
    }

    [TestClass]
    public class Repositorio_Usuario_Activo_Con_Rol
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("");
            var usuario = conexion.Usuarios!.FirstOrDefault(u => u.Activo == true && u.Roles != null);
            if (usuario != null)
                return;
            throw new Exception("No existe ningún usuario activo con rol asignado.");
        }
    }
}
