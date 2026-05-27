
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;
using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class Peliculas_Presentacion : IPeliculas_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/Peliculas";

        public List<Peliculas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarPeliculas";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Peliculas>();
            return JsonConvert.DeserializeObject<List<Peliculas>>(respuesta["Valor"].ToString()!)!;
        }

        public Peliculas Guardar(Peliculas entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardó");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarPelicula";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Peliculas();
            return JsonConvert.DeserializeObject<Peliculas>(respuesta["Valor"].ToString()!)!;
        }

        public Peliculas Modificar(Peliculas entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ModificarPelicula";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPut(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Peliculas();
            return JsonConvert.DeserializeObject<Peliculas>(respuesta["Valor"].ToString()!)!;
        }

        public Peliculas Eliminar(Peliculas entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/EliminarPelicula";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarDelete(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Peliculas();
            return JsonConvert.DeserializeObject<Peliculas>(respuesta["Valor"].ToString()!)!;
        }
    }
}
