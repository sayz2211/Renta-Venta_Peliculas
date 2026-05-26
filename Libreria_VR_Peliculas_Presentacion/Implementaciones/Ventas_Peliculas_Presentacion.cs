using Libreria_VR_Peliculas.Interfaces;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;
using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class Ventas_Peliculas_Presentacion : IVentas_Peliculas_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/Ventas_Peliculas";

        public List<Ventas_Peliculas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarVentasPeliculas";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Ventas_Peliculas>();
            return JsonConvert.DeserializeObject<List<Ventas_Peliculas>>(respuesta["Valor"].ToString()!)!;
        }

        public Ventas_Peliculas Guardar(Ventas_Peliculas entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardó");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarVentaPelicula";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Ventas_Peliculas();
            return JsonConvert.DeserializeObject<Ventas_Peliculas>(respuesta["Valor"].ToString()!)!;
        }
    }
}
