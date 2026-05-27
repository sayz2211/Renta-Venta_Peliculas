
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;
using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class Sucursales_Presentacion : ISucursales_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/Sucursales";

        public List<Sucursales> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarSucursales";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Sucursales>();
            return JsonConvert.DeserializeObject<List<Sucursales>>(respuesta["Valor"].ToString()!)!;
        }

        public Sucursales Guardar(Sucursales entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardó");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarSucursal";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Sucursales();
            return JsonConvert.DeserializeObject<Sucursales>(respuesta["Valor"].ToString()!)!;
        }

        public Sucursales Modificar(Sucursales entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ModificarSucursal";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPut(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Sucursales();
            return JsonConvert.DeserializeObject<Sucursales>(respuesta["Valor"].ToString()!)!;
        }

        public Sucursales Eliminar(Sucursales entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/EliminarSucursal";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarDelete(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Sucursales();
            return JsonConvert.DeserializeObject<Sucursales>(respuesta["Valor"].ToString()!)!;
        }
    }
}
