using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Libreria_VR_Peliculas.Implementaciones
{
    public class Usuarios_Negocio : IUsuarios_Negocio
    {
        private IConexion? iConexion;

        public List<Usuarios> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Usuarios!.ToList();
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Usuarios", Accion = "Consultar", Fecha = DateTime.Now, DatosNuevos = "Se consultaron registros de Usuarios" });
            iConexion.SaveChanges();
            return lista;
        }

        public Usuarios Guardar(Usuarios entidad)
        {
            if (entidad.Id != 0) throw new Exception("El registro ya tiene un ID asignado.");
            if (string.IsNullOrEmpty(entidad.NombreUsuario)) throw new Exception("El nombre de usuario es obligatorio.");
            if (string.IsNullOrEmpty(entidad.Contrasena)) throw new Exception("La contraseña es obligatoria.");
            if (string.IsNullOrEmpty(entidad.Correo)) throw new Exception("El correo es obligatorio.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var existe = iConexion.Usuarios!.Any(u => u.NombreUsuario == entidad.NombreUsuario || u.Correo == entidad.Correo);
            if (existe) throw new Exception("Ya existe un usuario con ese nombre o correo.");
            entidad.FechaRegistro = DateTime.Now;
            entidad.Activo = true;
            iConexion.Usuarios!.Add(entidad);
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Usuarios", Accion = "Guardar", Fecha = DateTime.Now, DatosNuevos = "Usuario creado: " + entidad.NombreUsuario });
            iConexion.SaveChanges();
            return entidad;
        }

        public Usuarios Modificar(Usuarios entidad)
        {
            if (entidad.Id == 0) throw new Exception("El registro no tiene un ID válido.");
            if (string.IsNullOrEmpty(entidad.NombreUsuario)) throw new Exception("El nombre de usuario es obligatorio.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entry = iConexion.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Usuarios", Accion = "Modificar", Fecha = DateTime.Now, DatosAnteriores = "Id: " + entidad.Id, DatosNuevos = "Usuario modificado: " + entidad.NombreUsuario });
            iConexion.SaveChanges();
            return entidad;
        }

        public Usuarios Eliminar(Usuarios entidad)
        {
            if (entidad.Id == 0) throw new Exception("El registro no tiene un ID válido.");
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.Usuarios!.Remove(entidad);
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Usuarios", Accion = "Eliminar", Fecha = DateTime.Now, DatosAnteriores = "Id: " + entidad.Id, DatosNuevos = null });
            iConexion.SaveChanges();
            return entidad;
        }

        public Usuarios? Login(string nombreUsuario, string contrasena)
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var usuario = iConexion.Usuarios!.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena && u.Activo == true);
            if (usuario == null) throw new Exception("Usuario o contraseña incorrectos.");
            iConexion.Auditorias!.Add(new Auditorias { Tabla = "Usuarios", Accion = "Login", Fecha = DateTime.Now, DatosNuevos = "Login exitoso: " + nombreUsuario });
            iConexion.SaveChanges();
            return usuario;
        }
    }
}
