
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;
using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class Rentas_Peliculas_Presentacion : IRentas_Peliculas_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/Rentas_Peliculas";

        public List<Rentas_Peliculas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarRentasPeliculas";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Rentas_Peliculas>();
            return JsonConvert.DeserializeObject<List<Rentas_Peliculas>>(respuesta["Valor"].ToString()!)!;
        }

        public Rentas_Peliculas Guardar(Rentas_Peliculas entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardó");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarRentaPelicula";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Rentas_Peliculas();
            return JsonConvert.DeserializeObject<Rentas_Peliculas>(respuesta["Valor"].ToString()!)!;
        }
    }
}
