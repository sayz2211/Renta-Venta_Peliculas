
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;
using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class Formatos_Peliculas_Presentacion : IFormatos_Peliculas_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/Formatos_Peliculas";

        public List<Formatos_Peliculas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarFormatosPeliculas";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Formatos_Peliculas>();
            return JsonConvert.DeserializeObject<List<Formatos_Peliculas>>(respuesta["Valor"].ToString()!)!;
        }

        public Formatos_Peliculas Guardar(Formatos_Peliculas entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardó");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarFormatoPelicula";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Formatos_Peliculas();
            return JsonConvert.DeserializeObject<Formatos_Peliculas>(respuesta["Valor"].ToString()!)!;
        }

        public Formatos_Peliculas Modificar(Formatos_Peliculas entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ModificarFormatoPelicula";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPut(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Formatos_Peliculas();
            return JsonConvert.DeserializeObject<Formatos_Peliculas>(respuesta["Valor"].ToString()!)!;
        }
    }
}
