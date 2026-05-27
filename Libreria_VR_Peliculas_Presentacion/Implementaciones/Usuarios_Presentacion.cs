
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;
using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class Usuarios_Presentacion : IUsuarios_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/Usuarios";

        public List<Usuarios> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarUsuarios";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Usuarios>();
            return JsonConvert.DeserializeObject<List<Usuarios>>(respuesta["Valor"].ToString()!)!;
        }

        public Usuarios Guardar(Usuarios entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardó");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarUsuario";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Usuarios();
            return JsonConvert.DeserializeObject<Usuarios>(respuesta["Valor"].ToString()!)!;
        }

        public Usuarios Modificar(Usuarios entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ModificarUsuario";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPut(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Usuarios();
            return JsonConvert.DeserializeObject<Usuarios>(respuesta["Valor"].ToString()!)!;
        }

        public Usuarios Eliminar(Usuarios entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/EliminarUsuario";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarDelete(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Usuarios();
            return JsonConvert.DeserializeObject<Usuarios>(respuesta["Valor"].ToString()!)!;
        }
        public Usuarios? Login(string nombreUsuario, string contrasena)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/LoginUsuario";
            datos["Entidad"] = new { NombreUsuario = nombreUsuario, Contrasena = contrasena };
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"].ToString());
            if (!respuesta.ContainsKey("Valor")) return null;
            return JsonConvert.DeserializeObject<Usuarios>(respuesta["Valor"].ToString()!)!;
        }

    }
}
